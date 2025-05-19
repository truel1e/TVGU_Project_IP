using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

  

    public partial class Form1 : Form
    {
        Bitmap b, b2;
        bool flagGr = false;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 255; i++) chart1.Series[0].Points.AddXY(i, 0);
            b = new Bitmap((string)Environment.CurrentDirectory + "\\myimg2.jpg");
            b2 = new Bitmap((string)Environment.CurrentDirectory + "\\myimg2.jpg");

            pictureBox1.Image = b;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flagGr = true;

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {

                    Color c = b.GetPixel(i, j);
                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = b2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    // byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    if (red + trackBar1.Value > 255) red = 255;
                    else if (red + trackBar1.Value < 0) red = 0;
                    else red += (byte)trackBar1.Value;

                    if (green + trackBar1.Value > 255) green = 255;
                    else if (green + trackBar1.Value < 0) green = 0;
                    else green += (byte)trackBar1.Value;

                    if (blue + trackBar1.Value > 255) blue = 255;
                    else if (blue + trackBar1.Value < 0) blue = 0;
                    else blue += (byte)trackBar1.Value;

                    if (flagGr == true)
                    {
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);
                        b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else {
                        b2.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                    

                }
            }
            pictureBox1.Image = b2;
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            int[] buf = new int[256];

            chart1.Series[0].Points.Clear();

            for (int i = 0; i < buf.Length; i++) buf[i] = 0;

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b2.GetPixel(i, j);

                    buf[((int)c.R + (int)c.B + (int)c.G)/3] += 1;
                }
            }

            for (int i = 0; i < buf.Length; i++)
            {
                chart1.Series[0].Points.AddY(buf[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    // byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;
                    
                    if (red > trackBar3.Value) red = (byte)(255 - (int)red);
                   
                    if (green > trackBar4.Value) green = (byte)(255 - (int)green);
                   
                    if (blue > trackBar5.Value) blue = (byte)(255 - (int)blue);

                    if (flagGr == false)
                    {
                        b2.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                    else {
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);
                        b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }

                }
            }
            pictureBox1.Image = b2;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar3.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar5.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar4.Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label11.Text = trackBar6.Value.ToString();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar7.Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Q1 = trackBar6.Value;
            int Q2 = trackBar7.Value;

            if (Q1 == Q2)
            {
                Q2 = Q1 + 1;
            }

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    // byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    if (red < Q1) red = 0;
                    else if (red > Q2) red = 255; 
                    else red = (byte)(255*(red - Q1)/(Q2-Q1));

                    if (green < Q1) green = 0;
                    else if (green > Q2) green = 255;
                    else green = (byte)(255 * (green - Q1) / (Q2 - Q1));

                    if (blue < Q1) blue = 0;
                    else if (blue > Q2) blue = 255;
                    else blue = (byte)(255 * (blue - Q1) / (Q2 - Q1));


                    if (flagGr == true)
                    {
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);
                        b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        b2.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }

                }
            }
            pictureBox1.Image = b2;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            label17.Text = trackBar9.Value.ToString();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            label15.Text = trackBar8.Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Q1 = trackBar9.Value;
            int Q2 = trackBar8.Value;

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    // byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    red = (byte)(Q1 + (float)red * (Q2-Q1) / 255);

                    green = (byte)(Q1 + (float)green * (Q2 - Q1) / 255);

                    blue = (byte)(Q1 + (float)blue * (Q2 - Q1) / 255);


                    if (flagGr == true)
                    {
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);
                        b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        b2.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }

                }
            }
            pictureBox1.Image = b2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool flag = checkBox1.Checked;

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    // byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    if (flag == false)
                    {
                        red = (byte)(255 * Math.Pow((float)red / 255, (float)numericUpDown1.Value));
                        green = (byte)(255 * Math.Pow((float)green / 255, (float)numericUpDown1.Value));
                        blue = (byte)(255 * Math.Pow((float)blue / 255, (float)numericUpDown1.Value));
                    }
                    else {

                        red = (byte)(255 * Math.Pow((float)red / 255, 1/(float)numericUpDown1.Value));
                        green = (byte)(255 * Math.Pow((float)green / 255, 1/(float)numericUpDown1.Value));
                        blue = (byte)(255 * Math.Pow((float)blue / 255, 1/(float)numericUpDown1.Value));
                    }

                    if (flagGr == true)
                    {
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);
                        b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        b2.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }

                }
            }
            pictureBox1.Image = b2;


        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    if (gray < trackBar2.Value) gray = 0;
                    else gray = 255;



                    b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));

                }
            }
            pictureBox1.Image = b2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) button9.BackColor = colorDialog1.Color;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) button10.BackColor = colorDialog1.Color;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) button11.BackColor = colorDialog1.Color;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) button12.BackColor = colorDialog1.Color;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color res = Color.Black;
                    Color c = b.GetPixel(i, j);
                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    if (gray < numericUpDown2.Value) res = button9.BackColor;
                    else if (gray < numericUpDown3.Value) res = button10.BackColor;
                    else if (gray < numericUpDown4.Value) res = button11.BackColor;
                    else if (gray < numericUpDown5.Value) res = button12.BackColor;
                    else res = Color.Red;


                    b2.SetPixel(i, j, res);
                }
            }
            pictureBox1.Image = b2;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            float N = (float)(256 / numericUpDown6.Value);

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color res;
                    Color c = b.GetPixel(i, j);
                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                                     
                    int v;

                    for (float g = N; g < 256; g += N) {
                        if (gray <g) {
                            v = (int)(g - N / 2);
                            res = Color.FromArgb(v, v, v);
                            b2.SetPixel(i, j, res);
                            break;
                        }
                    }
                }
            }
            pictureBox1.Image = b2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    gray = (byte)((float)(gray * (255 - gray)) / 64);

                    b2.SetPixel(i, j, Color.FromArgb(gray, gray, gray));

                }
            }
            pictureBox1.Image = b2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap((string)Environment.CurrentDirectory + "\\myimg2.jpg");
            b2 = new Bitmap(b.Width, b.Height);

            trackBar1.Value = 0;
            label3.Text = "0";
            trackBar2.Value = 0;
            label4.Text = "0";
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            trackBar5.Value = 0;
            label5.Text = "0";
            label6.Text = "0";
            label7.Text = "0";
            label11.Text = "0";
            trackBar6.Value = 0;
            label13.Text = "0";
            trackBar7.Value = 0;
            label17.Text = "0";
            trackBar9.Value = 0;
            label15.Text = "0";
            trackBar8.Value = 0;
            checkBox1.Checked = false;
            numericUpDown1.Value = 1;
            
           // Utilities.ResetAllControls(this);

            flagGr = false;

            pictureBox1.Image = b;
        }
    }
}

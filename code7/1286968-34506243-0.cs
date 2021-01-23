    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace RubberBand
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private Bitmap m_Orig = null;
            private int X0, X1, Y0, Y1;
            private bool sArea, hasMoved = false;
            private Bitmap sImg = null;
            private Graphics sGraph = null;
            private void Form1_Load(object sender, EventArgs e)
            {
                m_Orig = new Bitmap(pictureBox1.Image);
                this.KeyPreview = true;
            }
            private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 27)
                {
                    if (!sArea) return;
                    sArea = false;
                    hasMoved = false;
                    sImg = null;
                    sGraph = null;
                    pictureBox1.Image = m_Orig;
                    pictureBox1.Refresh();
                }
            }
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                sArea = true;
                X0 = e.X;
                Y0 = e.Y;
                sImg = new Bitmap(m_Orig);
                sGraph = Graphics.FromImage(sImg);
                pictureBox1.Image = sImg;
            }
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!sArea) return;
                    hasMoved = true;
                    X1 = e.X;
                    Y1 = e.Y;
                    sGraph.DrawImage(m_Orig, 0, 0);
                    using (Pen select_pen = new Pen(Color.Red))
                    {
                        select_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        Rectangle rect = MakeRectangle(X0, Y0, X1, Y1);
                        sGraph.DrawRectangle(select_pen, rect);
                    }
                    pictureBox1.Refresh();
                }
            }
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (!sArea) return;
                if (!hasMoved) return;
                sArea = false;
                hasMoved = false;
                sImg = null;
                sGraph = null;
                pictureBox1.Image = m_Orig;
                pictureBox1.Refresh();
                Rectangle rect = MakeRectangle(X0, Y0, X1, Y1);
                if ((rect.Width > 0) && (rect.Height > 0))
                {
                    MessageBox.Show(rect.ToString());
                }
            }
            private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
            {
                return new Rectangle(
                    Math.Min(x0, x1),
                    Math.Min(y0, y1),
                    Math.Abs(x0 - x1),
                    Math.Abs(y0 - y1));
            }
        }
    }

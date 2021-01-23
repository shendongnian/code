    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    
    namespace pezeshk
    {
        public partial class pen : Form
        {
            private SolidBrush myBrush;
            private Pen myPen;
            private Graphics myGraphics;
            private bool isDrawing = false;
            public pen()
            {
                InitializeComponent();
                myPen = new Pen(Color.ForestGreen);
                myBrush = new SolidBrush(Color.DarkSlateBlue);
            }
            void panel1_paint(object sender, PaintEventArgs e)
            {
                if (rb_pen.Checked)
                {
                    if (points.Count > 1) e.Graphics.DrawCurve(myPen, points.ToArray());
                    foreach (List<Point> lp in curves)
                        if (lp.Count > 1)
                            e.Graphics.DrawCurve(myPen, lp.ToArray());
    
    
                }
            }
            private void pen_Load(object sender, EventArgs e)
            {
                myBrush = new SolidBrush(panel2.BackColor);
                myGraphics = panel1.CreateGraphics();
              
    
            }
    
            private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    panel2.BackColor = colorDialog1.Color;
                    myBrush.Color = panel2.BackColor;
                }
            }
            Point mDown = Point.Empty;
            private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                mDown = e.Location;
            }
    
            private void panel1_MouseUp(object sender, MouseEventArgs e)
            {
                if (rb_pen.Checked)
                {
                    if (points.Count > 1) curves.Add(points.ToList());  // copy!!
                    points.Clear();
                    panel1.Invalidate();
                }
    
                
                panel1.Invalidate();
            }
            private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
    
                    if (rb_pen.Checked)
                    {
                        points.Add(e.Location);
    
                    }
                    panel1.Invalidate();
                }
            }
    
            List<Rectangle> circles = new List<Rectangle>();
            List<Point> points = new List<Point>();
            List<List<Point>> curves = new List<List<Point>>();
            private void button1_Click(object sender, EventArgs e)
            {
                string somefolder = "D:\\"; using (Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height))
                {
                    panel1.DrawToBitmap(bmp, panel1.ClientRectangle); bmp.Save(somefolder + panel1.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                } 
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                curves.Clear(); points.Clear(); panel1.Invalidate();
            }
    
        }
        class DrawPanel : Panel
        {
            public DrawPanel() { DoubleBuffered = true; }
        }
    
    }

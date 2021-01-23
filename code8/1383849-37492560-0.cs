    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace CustomButton
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Point[] pts = 
                {
                    new Point(40, 40),
                    new Point(70, 40),
                    new Point(100, 70),
                    new Point(100, 100),
                    new Point(70, 130),
                    new Point(40, 130),
                    new Point(10, 100),
                    new Point(10, 70)
                };
    
                GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
                polygon_path.AddPolygon(pts);
                Region polygon_region = new Region(polygon_path);
                button1.Region = polygon_region;
                button1.Padding = new Padding(5, 35, 0, 0);
                button1.SetBounds(button1.Location.X, button1.Location.Y, pts[3].X + 5, pts[4].Y + 5);
                button1.BackColor = Color.Red;
                button1.ForeColor = Color.White;
                button1.TextAlign = ContentAlignment.MiddleCenter;
                button1.UseCompatibleTextRendering = true;
                button1.Text = "Stop";
            }
        }
    }

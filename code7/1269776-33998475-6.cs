    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Point startPoint;
            private Point endPoint;
            private Image mandelbrotCache;
            private Pen rectPen;
    
            public Form1()
            {
                InitializeComponent();
    
                // this reduces the flickering
                this.DoubleBuffered = true;
    
                // initialize a dummy image. Cache a copy of your Mandelbrot fractal here
                mandelbrotCache = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                using (var g = Graphics.FromImage(mandelbrotCache))
                {
                    var imgRect = new Rectangle(0, 0,
                                                mandelbrotCache.Width,
                                                mandelbrotCache.Height);
    
                    g.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.DarkBlue,
                                    Color.LightBlue), imgRect);
                }
    
                // this is the pen to draw the rectangle with
                rectPen = new Pen(Color.Red, 3);
            }
    
            private Rectangle CreateRectangle(Point pt1, Point pt2)
            {
                // we use this method to create a rectangle with positive width and height
                int x1 = Math.Min(pt1.X, pt2.X);
                int y1 = Math.Min(pt1.Y, pt2.Y);
    
                return new Rectangle(x1, y1, Math.Abs(pt1.X - pt2.X), Math.Abs(pt1.Y - pt2.Y));
            }
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    this.startPoint = e.Location;// record the start position
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // record the current position as the end point if the left button is down
                    this.endPoint = e.Location;
                    // force a redraw
                    this.Invalidate();
                }
            }
    
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    // setting the point to -1,-1 makes them get drawn off the screen
                    startPoint = new Point(-1, -1);
                    endPoint = new Point(-1, -1);
    
                    // force an update so that the rectangle disappears
                    this.Invalidate();
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                // draw the cached Mandelbrot image
                e.Graphics.DrawImage(mandelbrotCache, new Point(0, 0));
    
                // draw the current rectangle
                e.Graphics.DrawRectangle(rectPen, CreateRectangle(startPoint, endPoint));
            }
        }
    }

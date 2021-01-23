    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    
    namespace DrawExample
    {
        public partial class Form1 : Form
        {
    
            private Bitmap _canvas; //This is the offscreen drawing buffer
            private Point _anchor; //The start point for click-drag operations
            private Rectangle? _ghost;
            private Brush _ghostBrush;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _ghostBrush = new SolidBrush(Color.FromArgb(200, 200, 200, 255)); //This creates a slightly blue, transparent brush for the ghost preview
                ResizeCanvas();
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                ResizeCanvas();
            }
    
            /// <summary>
            /// Resizes the offscreen bitmap to match the current size of the window, it preserves what is currently in the bitmap.
            /// </summary>
            private void ResizeCanvas()
            {
                Bitmap tmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
                using (Graphics g = Graphics.FromImage(tmp))
                {
                    g.Clear(Color.White);
                    if (_canvas != null)
                    {
                        g.DrawImage(_canvas, 0, 0);
                        _canvas.Dispose();
                    }
                }
                _canvas = tmp;
            }
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _anchor = new Point(e.X, e.Y);
                }
            }
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _ghost = new Rectangle(_anchor.X, _anchor.Y, e.X - _anchor.X, e.Y - _anchor.Y);
                    this.Invalidate();
                }
            }
    
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //Create a Graphics for the offscreen bitmap
                    using (Graphics g = Graphics.FromImage(_canvas))
                    {
                        Rectangle rect = new Rectangle(_anchor.X, _anchor.Y, e.X - _anchor.X, e.Y - _anchor.Y);
                        g.FillRectangle(Brushes.White, rect);
                        g.DrawRectangle(Pens.Black, rect);
                    }
    
                    _ghost = null;
    
                    //This queues up a redraw call for the form
                    this.Invalidate();
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
    
                if (_ghost.HasValue)
                {
                    using (Bitmap tmp = new Bitmap(_canvas))
                    {
                        using (Graphics g = Graphics.FromImage(tmp))
                        {
                            g.FillRectangle(_ghostBrush, _ghost.Value);
                            g.DrawRectangle(Pens.Black, _ghost.Value);
    
                            e.Graphics.DrawImage(tmp, 0, 0);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawImage(_canvas, 0, 0);
                }
            }
    
    
            //This stops the flickering
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                //Do nothing
            }
        }
    }

    namespace Baum
    {
        using System;
        using System.Drawing;
        using System.Drawing.Drawing2D;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
                PointF[] tree = new PointF[]
                {
                    new PointF(12, 0),
                    new PointF(16, 4),
                    new PointF(13, 4),
                    new PointF(19, 11),
                    new PointF(13, 11),
                    new PointF(21, 20),
                    new PointF(3, 20),
                    new PointF(11, 11),
                    new PointF(5, 11),
                    new PointF(11, 4),
                    new PointF(8, 4)
                };
    
                PointF[] stump = new PointF[]
                {
                    new PointF(10, 20),
                    new PointF(14, 20),
                    new PointF(14, 27),
                    new PointF(19, 27),
                    new PointF(19, 30),
                    new PointF(6, 30),
                    new PointF(6, 27),
                    new PointF(10, 27)
                };
    
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddPolygon(tree);
                    Matrix m = new Matrix();
                    m.Scale(20, 20);
                    path.Transform(m);
                    e.Graphics.FillPath(Brushes.Green, path);
    
                    foreach (PointF p in path.PathPoints)
                    {
                        int s = 15;
                        PointF q = p;
                        q.X -= (s / 2);
                        q.Y -= (s / 2);
    
                        if (new Random(Guid.NewGuid().GetHashCode()).Next(0, tree.Length) > tree.Length / 2)
                        {
                            e.Graphics.FillEllipse(Brushes.Red, new RectangleF(q.X, q.Y, s, s));
                        }
                    }
                }
    
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddPolygon(stump);
                    Matrix m = new Matrix();
                    m.Scale(20, 20);
                    path.Transform(m);
                    e.Graphics.FillPath(Brushes.Brown, path);
                }
    
                System.Threading.Thread.Sleep(500);
                Refresh();
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        }
    }

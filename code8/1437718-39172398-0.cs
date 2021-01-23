    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    namespace CircleTest
    {
        public partial class Form1 : Form
        {
            private CircleManager circleManager = new CircleManager();
            private Font font = new Font("Tahoma", 8, FontStyle.Bold);
            public Color normalFillColor = Color.White;
            public Color selectedFillColor = Color.Red;
            public Color borderColor = Color.Gray;
            public int borderWith = 2;
            public Form1()
            {
                InitializeComponent();
                pictureBox1.Paint += new PaintEventHandler(pic_Paint);
            }
            private void pic_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics g = e.Graphics;
                DrawCircles(g);
            }
            public void DrawCircles(Graphics g)
            {
                for (int i = 0; i < circleManager.CircleShapes.Count; i++)
                {
                    using (var brush = new SolidBrush(circleManager.Circles[i].Selected ? selectedFillColor : normalFillColor))
                        g.FillEllipse(brush, circleManager.CircleShapes[i]);
                    using (var pen = new Pen(borderColor, 2))
                        g.DrawEllipse(pen, circleManager.CircleShapes[i]);
                    TextRenderer.DrawText(g, i.ToString(), font,
                        circleManager.CircleShapes[i], Color.Black,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
            }
            private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Circle newCircle = new Circle();
                    newCircle.Name = (circleManager.Circles.Count + 1).ToString();
                    Location.Offset(-newCircle.size.Width / 2, -newCircle.size.Height / 2);
                    newCircle.Location = e.Location;
                    circleManager.Circles.Add(newCircle);
                    circleManager.CircleShapes.Add(new Rectangle(newCircle.Location, newCircle.size));
                    pictureBox1.Invalidate();
                }
            }
            private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
            {
                if (ModifierKeys != Keys.Control && e.Button != MouseButtons.Right)
                {
                    return;
                }
                else
                {
                    circleManager.HitTest(e.Location);
                }
                pictureBox1.Invalidate();
            }
        }
        public class CircleManager
        {
            public List<Circle> Circles = new List<Circle>();
            public List<Rectangle> CircleShapes = new List<Rectangle>();
            public void HitTest(Point p)
            {
                for (int i = 0; i < CircleShapes.Count; i++)
                {
                    using (var path = new GraphicsPath())
                    {
                        path.AddEllipse(CircleShapes[i]);
                        if (path.IsVisible(p))
                        {
                            Circles[i].Selected = true;
                        }
                    }
                }
            }
        }
        public class Circle
        {
            public string Name { get; set; }
            public Point Location { get; set; }
            public Size size = new Size(25, 25);
            public bool Selected { get; set; }
            public Rectangle Bounds
            {
                get
                {
                    return new Rectangle(Location, size);
                }
            }
        }
    }

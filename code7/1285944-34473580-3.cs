    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly List<List<Point>> _points = new List<List<Point>>();
            private readonly List<GraphicsPath> _graphicsPaths = new List<GraphicsPath>();
    
            public Form1()
            {
                InitializeComponent();
    
                _points.AddRange(new[] 
                {
                    new List<Point>
                    {
                        new Point(19, 62),
                        new Point(28, 57),
                        new Point(27, 84),
                        new Point(16, 85)
                    },
                    new List<Point>
                    {
                        new Point(52, 53),
                        new Point(62, 50),
                        new Point(61, 77),
                        new Point(49, 78)
                    },
                    new List<Point>
                    {
                        new Point(87, 49),
                        new Point(100, 48),
                        new Point(99, 75),
                        new Point(86, 74)
                    }
                });
    
                foreach (var points in _points)
                {
                    var path = new GraphicsPath();
                    path.AddPolygon(points.ToArray());
                    _graphicsPaths.Add(path);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // Form
                Height = 200;
                Width = 100;
    
                // Label
                Label label = new Label
                {
                    Text = @"Border clicked",
                    Visible = false
                };
    
                // Panel
                Panel panel = new Panel
                {
                    Height = 400,
                    Width = 400,
                    BackColor = Color.White,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
    
                panel.Paint += (o, args) =>
                {
                    using (Graphics graphics = panel.CreateGraphics())
                    {
                        foreach (GraphicsPath path in _graphicsPaths)
                            graphics.DrawPath(new Pen(Color.Blue, 3), path);
                    }
                };
    
                panel.MouseDown += (o, args) =>
                {
                    Point mousePoint = new Point(args.X, args.Y);
                    using (Pen pen = new Pen(Color.Transparent, 0F))
                    {
                        GraphicsPath path = _graphicsPaths.FirstOrDefault(p => p.IsOutlineVisible(mousePoint, pen));
                        if (path == null)
                            return;
    
                        Task.Run(() =>
                        {
                            label.Invoke((Action)(() => label.Visible = true));
                            Thread.Sleep(500);
                            label.Invoke((Action)(() => label.Visible = false));
                        });
                    }
                };
                panel.Controls.Add(label);
                
                Controls.Add(panel);
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                foreach (GraphicsPath path in _graphicsPaths)
                    path.Dispose();
            }
        }
    }

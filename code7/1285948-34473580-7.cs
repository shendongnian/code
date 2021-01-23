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
        // It's preferred to use established naming conventions,
        // such as prefixing private fields with "_".
        // Declaring access modifiers explicitly, even default modifier
        // "private", is advised because it makes reading thousands lines of code
        // that much easier (one can expect first keyword to be access modifier)
        public partial class Form1 : Form
        {
            // For convenience and readability, 
            // I'd prefer Lists and List-of-Lists over arrays
            private readonly List<List<Point>> _points = new List<List<Point>>();
            private readonly List<GraphicsPath> _graphicsPaths = new List<GraphicsPath>();
    
            public Form1()
            {
                InitializeComponent();
                // Points to create paths from    
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
                // Create GDI graphics paths    
                foreach (List<Point> points in _points)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddPolygon(points.ToArray());
                    _graphicsPaths.Add(path);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // Adjust form
                Height = 200;
                Width = 100;
    
                // Create label and panel
                // No need for these to be private fields
                Label label = new Label
                {
                    Text = @"Border clicked",
                    Visible = false
                };
    
                // Create panel
                Panel panel = new Panel
                {
                    Height = 400,
                    Width = 400,
                    BackColor = Color.White,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                // Paint event handler.
                // Personally I prefer inline anonymous methods
                // over named methods when logic is simple 
                // and it's not being reused    
                panel.Paint += (o, args) =>
                {
                    // 'using' because we want to get rid of Graphics
                    // and Pen when we are done drawing paths
                    using (Graphics graphics = panel.CreateGraphics())
                    {
                        using (Pen pen = new Pen(Color.Blue, 3))
                        {
                            foreach (GraphicsPath path in _graphicsPaths)
                                graphics.DrawPath(pen, path);
                        }
                    }
                };
                // Mouse (down) event handler.     
                panel.MouseDown += (o, args) =>
                {
                    // Get mouse point
                    Point mousePoint = new Point(args.X, args.Y);
                    // Again, we want to dispose Pen
                    using (Pen pen = new Pen(Color.Transparent, 0F))
                    {
                        // Get first path under mouse pointer  
                        GraphicsPath path = _graphicsPaths.FirstOrDefault(p =>
                            p.IsOutlineVisible(mousePoint, pen));
                        if (path == null)
                            return;
    
                        // If found, "flash" our informative label
                        // in non-blocking way  
                        Task.Run(() =>
                        {
                            label.Invoke((Action)(() => label.Visible = true));
                            Thread.Sleep(500);
                            label.Invoke((Action)(() => label.Visible = false));
                        });
                    }
                };
                // Add controls to containers 
                panel.Controls.Add(label);                
                Controls.Add(panel);
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                // This could be more reasonable place to dispose
                // GDI Graphics path created earlier? 
                foreach (GraphicsPath path in _graphicsPaths)
                    path.Dispose();
                _graphicsPaths.Clear();
            }
        }
    }

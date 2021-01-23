    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private PointF[] _points;
        private void FractalDisplay_Load(object sender, EventArgs e)
        {
            Redraw();
        }
        private void Redraw()
        {
            List<PointF> points = new List<PointF>();
            GenerateHilbert(0, 0, 1, 0, 0, 1, (int)numericUpDown1.Value, points);
            _points = points.ToArray();
            Invalidate();
        }
        private void GenerateHilbert(PointF origin, float xi, float xj, float yi, float yj, int depth, List<PointF> points)
        {
            if  (depth <= 0)
            {
                PointF current = origin + new SizeF((xi + yi) / 2, (xj + yj) / 2);
                points.Add(current);
            }
            else
            {
                GenerateHilbert(origin, yi / 2, yj / 2, xi / 2, xj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2, xj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2 + yi / 2, xj / 2 + yj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, points);
                GenerateHilbert(origin + new SizeF(xi / 2 + yi, xj / 2 + yj), -yi / 2, -yj / 2, -xi / 2, -xj / 2, depth - 1, points);
            }
        }
        // Perform the Actual Drawing
        private void HilbertCurve_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (_points != null)
            {
                float scale = Math.Min(ClientSize.Width, ClientSize.Height);
                e.Graphics.ScaleTransform(scale, scale);
                using (Pen pen = new Pen(Color.Red, 1 / scale))
                {
                    e.Graphics.DrawLines(pen, _points);
                }
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Redraw();
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Invalidate();
        }
    }

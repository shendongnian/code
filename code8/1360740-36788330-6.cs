    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private PointF _previousPoint;
        private PointF[] _points;
        private void FractalDisplay_Load(object sender, EventArgs e)
        {
            Redraw();
        }
        private void Redraw()
        {
            List<PointF> points = new List<PointF>();
            // Start here, to provide a bit of margin within the client area of the window
            _previousPoint = new PointF(0.025f, 0.025f);
            points.Add(_previousPoint);
            int depth = (int)numericUpDown1.Value;
            float gridCellCount = (float)(Math.Pow(2, depth) - 1);
            // Use only 95% of the available space in the client area. Scale
            // the delta for drawing to fill that 95% width/height exactly,
            // according to the number of grid cells the given depth will
            // produce in each direction.
            GenerateHilbert3(depth, 0, 0.95f / gridCellCount, points);
            _points = points.ToArray();
            Invalidate();
        }
        private void GenerateHilbert(int depth, float xDistance, float yDistance, List<PointF> points)
        {
            if (depth < 1)
            {
                return;
            }
            GenerateHilbert(depth - 1, yDistance, xDistance, points);
            DrawRelative(xDistance, yDistance, points);
            GenerateHilbert(depth - 1, xDistance, yDistance, points);
            DrawRelative(yDistance, xDistance, points);
            GenerateHilbert(depth - 1, xDistance, yDistance, points);
            DrawRelative(-xDistance, -yDistance, points);
            GenerateHilbert(depth - 1, -yDistance, -xDistance, points);
        }
        private void DrawRelative(float xDistance, float yDistance, List<PointF> points)
        {
            // Discover where the new X and Y points will be
            PointF currentPoint = _previousPoint + new SizeF(xDistance, yDistance);
            // Paint from the current position of X and Y to the new positions of X and Y
            points.Add(currentPoint);
            // Update the Current Location of X and Y
            _previousPoint = currentPoint;
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

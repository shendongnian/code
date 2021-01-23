    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void Redraw()
        {
            Invalidate();
        }
        private PointF GenerateHilbert(PointF origin, float xi, float xj, float yi, float yj, int depth,
            PointF? previous, Graphics graphics, Pen pen)
        {
            if (depth <= 0)
            {
                PointF current = origin + new SizeF((xi + yi) / 2, (xj + yj) / 2);
                if (previous != null)
                {
                    graphics.DrawLine(pen, previous.Value, current);
                }
                return current;
            }
            else
            {
                previous = GenerateHilbert(origin, yi / 2, yj / 2, xi / 2, xj / 2, depth - 1, previous, graphics, pen);
                previous = GenerateHilbert(origin + new SizeF(xi / 2, xj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, previous, graphics, pen);
                previous = GenerateHilbert(origin + new SizeF(xi / 2 + yi / 2, xj / 2 + yj / 2), xi / 2, xj / 2, yi / 2, yj / 2, depth - 1, previous, graphics, pen);
                return GenerateHilbert(origin + new SizeF(xi / 2 + yi, xj / 2 + yj), -yi / 2, -yj / 2, -xi / 2, -xj / 2, depth - 1, previous, graphics, pen);
            }
        }
        // Perform the Actual Drawing
        private void HilbertCurve_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            float scale = Math.Min(ClientSize.Width, ClientSize.Height);
            e.Graphics.ScaleTransform(scale, scale);
            using (Pen pen = new Pen(Color.Red, 1 / scale))
            {
                GenerateHilbert(new PointF(), 1, 0, 0, 1, (int)numericUpDown1.Value, null, e.Graphics, pen);
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

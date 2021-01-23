        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 500;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 500;
        }
        List<Point> points = new List<Point>();
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            chart1.Invalidate();
        }
        private void chart1_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count < 2) return;
            chart1.Series[0].Points.Clear();
            foreach(Point pt in points)
            {
                double dx = chart1.ChartAreas[0].AxisX.PixelPositionToValue(pt.X);
                double dy = chart1.ChartAreas[0].AxisY.PixelPositionToValue(pt.Y);
                chart1.Series[0].Points.AddXY(dx, dy);
            }
            if (points.Count > 1)
                e.Graphics.DrawLines(Pens.Red, points.ToArray());
        }

    using System.Windows.Forms.DataVisualization.Charting;
    class UpdateGraph
    {
        public Chart Chart1 { get; set; }
        public UpdateGRaph(Chart chart)
        {
            Chart1 = chart;
        }
        public void AddGraphPoints()
        {
            Chart1.Series.Points.AddXY(0, 10);
        }
    }

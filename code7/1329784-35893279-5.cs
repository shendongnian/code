    void addCustomLabels(Chart chart)
    {
        Series S1 = chart.Series[0];
        ChartArea CA = chart.ChartAreas[0];
        CA.AxisX.CustomLabels.Clear();
        for (int i = 0; i < S1.Points.Count; i++)
        {
            CustomLabel cl = new CustomLabel();
            cl.FromPosition = S1.Points[i].XValue - 10;
            cl.ToPosition = S1.Points[i].XValue + 10;
            cl.Text = S1.Points[i].AxisLabel;
            CA.AxisX.CustomLabels.Add(cl);
        }
    }

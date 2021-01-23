    private void button1_Click(object sender, EventArgs e)
    {
        chart1.Series.Clear();
        Series S = chart1.Series.Add("S1");
        S.ChartType = SeriesChartType.Column;
        Random R = new Random(123);
        int sum = 0;
        for (int m = 1; m <= 10; m++)
        {
            int yval = R.Next(100);
            int p = S.Points.AddXY(m, yval);
            S.Points[p].Label = "#VAL \n #PERCENT";
            S.Points[p].AxisLabel = "#VAL \n #PERCENT";  // <-- !!
           sum += yval; 
        }
        chart1.ChartAreas[0].AxisX.Maximum = S.Points.Count;
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        button1.Text = sum + " total";
    }

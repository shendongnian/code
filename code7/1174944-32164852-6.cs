    private void button1_Click(object sender, EventArgs e)
    {
        chart1.Series.Clear();
        Series S = chart1.Series.Add("S1");
        S.ChartType = SeriesChartType.StackedColumn;
        S.SetCustomProperty("PixelPointWidth", "20"); // <- control the column width in pixels
        Random R = new Random(123);
        DateTime dt = Convert.ToDateTime("2015-01-01");
        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yy";
        for (int m = 1; m < 12; m++)
        {
            // here we add only a few points:
            if (m <= 2) S.Points.AddXY(dt.AddMonths(m), R.Next(100));  
        }
        // to control the displayed time range we set a Maximum
        chart1.ChartAreas[0].AxisX.Maximum = dt.AddMonths(12).ToOADate();
    }

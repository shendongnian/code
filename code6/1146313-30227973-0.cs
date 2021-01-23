    private void button1_Click(object sender, EventArgs e)
    {
        for (var i = 1.0; i < 30.0; ++i)
        {
            chart1.Series["Series1"].Points.AddXY(i, (116.0 / 30.0) * (31.0 - i));
        }
        chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
        chart1.Series["Series1"].Color = Color.Red;
        chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
    }

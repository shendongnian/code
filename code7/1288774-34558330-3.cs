    private void button1_Click(object sender, EventArgs e)
    {
        // create TWO series!
        chart1.Series.Clear();
        chart1.Series.Add("Data");
        chart1.Series.Add("Line of best fit");
        chart1.Series[0].ChartType = SeriesChartType.Point;
        chart1.Series[1].ChartType = SeriesChartType.Line;
        List<int> levels = new List<int>() { 8, 2, 11, 6, 5, 4, 12, 9, 6, 1};
        List<int> scores = new List<int>() { 3, 10, 3, 6, 8, 12, 1, 4, 9, 14};
        double minX = levels.ToList().Min();
        double maxX = levels.ToList().Max();
        double meanX = 1f * levels.Sum() / levels.Count;
        double meanY = 1f * scores.Sum() / scores.Count;
        double st = 0;
        double sb = 0;
        for (int i = 0; i < levels.Count; i++ )
        {
            st += (levels[i] - meanX) * (scores[i] - meanY);
            sb += (levels[i] - meanX) * (levels[i] - meanX);
        }
        double slope = st / sb;
        double y0 = meanY - slope * meanX;
        for (int i = 0; i < levels.Count; i++)
        {
                chart1.Series[0].Points.AddXY(levels[i], scores[i]);
        }
        // this is the part that creates the line of best fit:
        chart1.Series[1].Points.AddXY(minX, y0 + minX * slope);
        chart1.Series[1].Points.AddXY(maxX, y0 + maxX * slope);
    }

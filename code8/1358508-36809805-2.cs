    List<PointF> data = new List<PointF>();
    Timer timer = new Timer();
    private void button1_Click_1(object sender, EventArgs e)
    {
        data.Clear();
            
        for (int i = 0; i < 400; i++)
        {
            float x = i / 50f * (float)( Math.Cos(i / 10f));
            float y = i / 50f * (float)(Math.Sin(i / 10f));
            data.Add(new PointF(x,y));
        }
        chart1.Series.Clear();
        Series S1 = chart1.Series.Add("S1");
        Series S2 = chart1.Series.Add("S2");
        S2.MarkerSize = 2;
        S2.MarkerStyle = MarkerStyle.Circle;
        S2.Color = Color.Green;
        S1.Color = Color.FromArgb(64, Color.Red);
        S1.BorderWidth = 9;
        S2.ChartType = SeriesChartType.Point;
        S1.ChartType = SeriesChartType.Line;
        chart1.ChartAreas[0].AxisX.Minimum = -10;
        chart1.ChartAreas[0].AxisX.Maximum = 10;
        chart1.ChartAreas[0].AxisY.Minimum = -10;
        chart1.ChartAreas[0].AxisY.Maximum = 10;
        chart1.ChartAreas[0].BackColor = Color.White;
        timer.Interval = 15;
        timer.Start();
    }

    private void From1_Load(object sender, EventArgs e)
    {
        chart1.Series.Clear();
        chart1.Series.Add("Serie1");
        chart1.ChartAreas[0].AxisY.Minimum = 0;
        chart1.ChartAreas[0].AxisY.Maximum = 200;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        int y = new Random().Next(0, 200);
        chart1.Series[0].Points.Clear();
        chart1.Series[0].Points.AddXY(30, y);
    }

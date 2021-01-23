    void Form1_Load(object sender, EventArgs e)
    {
        chart1.ChartAreas[0].AxisY.Interval = 6000;
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            chart1.Series[0].Points.Add(random.Next(6000, 20000));
        }
    }

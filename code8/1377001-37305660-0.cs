        private void Form1_Load(object sender, EventArgs e)
        {
            DataPoint dp1 = new DataPoint(1, new double[] { 5, 15 });
            dp1.MarkerStyle = MarkerStyle.Triangle;
            dp1.MarkerSize = 12;
            dp1.MarkerColor = Color.Red;
            DataPoint dp2 = new DataPoint(1, new double[] { 15, 20 });
            chart1.Series[0].Points.Add(dp1);
            chart1.Series[0].Points.Add(dp2);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Series[0].Points.Add(new DataPoint(1, new double[] { 10, 60, 20, 50, 30, 40 }));
            Chart1.Series[0].Points.Add(new DataPoint(2, new double[] { 40, 90, 50, 80, 60, 70 }));
            Chart1.Series[0].Points.Add(new DataPoint(3, new double[] { 20, 70, 30, 60, 40, 50 }));
        }

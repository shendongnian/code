        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Series[0].Points.Add(new DataPoint { IsEmpty = false, XValue = DateTime.Now.AddDays(1).ToOADate(), YValues = new double[] { 50 } });
            Chart1.Series[0].Points.Add(new DataPoint { IsEmpty = false, XValue = DateTime.Now.AddDays(2).ToOADate(), YValues = new double[] { 70 } });
            Chart1.Series[0].Points.Add(new DataPoint { IsEmpty = true, XValue = DateTime.Now.AddDays(3).ToOADate(), YValues = new double[] { 0 } });
            Chart1.Series[0].Points.Add(new DataPoint { IsEmpty = false, XValue = DateTime.Now.AddDays(4).ToOADate(), YValues = new double[] { 30 } });
            Chart1.Series[0].Points.Add(new DataPoint { IsEmpty = false, XValue = DateTime.Now.AddDays(5).ToOADate(), YValues = new double[] { 60 } });
        }

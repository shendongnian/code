        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataCollection data = new MyDataCollection();
            foreach (MyData d in data)
                Chart1.Series[0].Points.AddXY(d.MyItem, new object[] { d.MyDate[0], d.MyDate[1] });
            Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "MMMM";
            Chart1.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Months;
            Chart1.ChartAreas[0].AxisY.Interval = 1;
            Chart1.ChartAreas[0].AxisY.Maximum = data.Max(d => d.MyDate[1]).ToOADate();
        }

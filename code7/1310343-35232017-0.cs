        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(1, new object[] { new DateTime(2016, 2, 8), new DateTime(2016, 2, 25) });
            chart1.Series[0].Points.AddXY(2, new object[] { new DateTime(2016, 2, 8), new DateTime(2016, 2, 11) });
            chart1.Series[0].Points.AddXY(2, new object[] { new DateTime(2016, 2, 15), new DateTime(2016, 2, 18) });
            chart1.Series[0].Points.AddXY(2, new object[] { new DateTime(2016, 2, 22), new DateTime(2016, 2, 25) });
        }

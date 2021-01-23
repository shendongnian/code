            private void chart()
        {
            chart1.Series["new"].Points.Clear();
            chart1.Series["new"].Points.AddXY("Peter", "1000");
            chart1.Series["new"].Points.AddXY("Julia", "1000");
        }

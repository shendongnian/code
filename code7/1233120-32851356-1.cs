        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
                chart1.Series["Series1"].Points.AddXY(i, r.Next(0, 50));
            for (int i = 0; i < 10; i++)
                chart1.Series["Series2"].Points.AddXY(0, r.Next(50, 100));
            chart1.Series["Series3"].Points.AddXY(0, 0);
        }

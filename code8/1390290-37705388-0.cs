    DateTime minValue, maxValue;
        int i = 0;
        public Form6()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "HH:mm:ss";
            
            minValue = DateTime.Now;       
            maxValue = minValue.AddSeconds(60);
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 5;
            System.DateTime x1 = new System.DateTime(2016, 6, 8, 12, 00, 00);
            System.DateTime x2 = new System.DateTime(2016, 6, 8, 23, 00, 00);
            chart1.ChartAreas[0].AxisY.Maximum = x2.ToOADate();
            chart1.ChartAreas[0].AxisY.Minimum = x1.ToOADate();
         
            timer1.Start();
          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime x = DateTime.Now;
            chart1.Series[0].Points.AddXY(i, x.ToOADate());
            i++;
        }

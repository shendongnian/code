        public Form7()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            timer1.Start();           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {  
            Random Rand_Value = new Random();
            int ValueToAdd = Rand_Value.Next(1, 100);
            //listBox1.Items.Add(ValueToAdd.ToString());
            chart1.Series[0].Points.AddY(ValueToAdd);
        }

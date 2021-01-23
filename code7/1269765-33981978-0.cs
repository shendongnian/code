        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = (1 * 60 * 1000); // 1 mins
            MyTimer.Tick += new EventHandler(times);
            MyTimer.Start();
        }
        private void times(object sender, EventArgs e)
        {
            DateTime t1 = DateTime.Parse("11:47:00.000");
            DateTime t2 = DateTime.Parse("11:50:00.000");
            DateTime now = DateTime.Now;
            if (t1 <= now && t2 >= now)
            {
                MessageBox.Show("done ");
            }
        }

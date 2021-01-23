        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 25;
            t.Tick += new EventHandler(Timer_Tick);
            t.Start();
        }
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            this.label1.Text = dllRef.GetText();
        }

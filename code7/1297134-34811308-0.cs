        public Action NextAction;
        public bool Running;
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Interval = 5000;
            timer1.Start();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (!Running && NextAction != null)
            {
                Running = true;
                NextAction();
                Running = false;
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            NextAction = () => TaskMethod();
        }
        void TaskMethod()
        {
            // do something
        }

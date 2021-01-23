        private System.Threading.Timer m_timer = null;
        private const int DUE_TIME = 1000;
        private const int INTERVAL = 1000;
        private void Page_Load(object sender, EventArgs e)
        {
            System.Threading.AutoResetEvent autoEvent = new System.Threading.AutoResetEvent(false);
            System.Threading.TimerCallback tcb = new System.Threading.TimerCallback(timer_Elapsed);
            m_timer = new System.Threading.Timer(tcb, null, DUE_TIME, INTERVAL);
        }
        void timer_Elapsed(object sender)
        {
            label1.Invoke((Action)(() =>
            {
                int lbl = Convert.ToInt32(label1.Text);
                label1.Text = (lbl + 1).ToString();
            }));
        }

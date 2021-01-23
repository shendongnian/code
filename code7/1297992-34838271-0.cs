     AutoResetEvent wh = new AutoResetEvent(false);
        Thread th;
        private delegate void SetLabelTextDelegate(string text);
        public Form1()
        {
            InitializeComponent();
        }
        public void thread()
        {
            // Check if we need to call BeginInvoke.
            if (this.InvokeRequired)
            {
                // Pass the same function to BeginInvoke,
                this.BeginInvoke(new SetLabelTextDelegate(SetLabelText),
                                                 new object[] { "loading..." });
            }
            wh.WaitOne();
        }
        private void SetLabelText(string text)
        {
            label1.Text = text;
        }

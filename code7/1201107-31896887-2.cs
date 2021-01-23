        private EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 26; i++)
                {
                    ewh.WaitOne();
                    Action updateLable = () => label1.Text = "" + i;
                    label1.BeginInvoke(updateLable);
                }
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ewh.Set();
        }

        private System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
        private async void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 21; i++)
            {
                label1.Text = i.ToString();
                mre.Reset();
                await Task.Factory.StartNew(() => { mre.WaitOne(); });
            }
            button1.Enabled = false;
            label1.Text = "Done!";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mre.Set();
        }

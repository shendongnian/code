        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew<int>(() => DelayedAdd(5, 10))
                .ContinueWith(t => DelayedAdd(t.Result, 20))
                .ContinueWith(t => DelayedAdd(t.Result, 30))
                .ContinueWith(t => DelayedAdd(t.Result, 50));
        }
        private int DelayedAdd(int a, int b)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke((Action)(() => textBox1.Text = (a + b).ToString()));
            }
            Thread.Sleep(500);
            return a + b;
        }

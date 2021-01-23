        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew<int>(() => DelayedAdd(5, 10))
        .ContinueWith(t => UpdateText(t.Result),
            TaskScheduler.FromCurrentSynchronizationContext())
        .ContinueWith(t => DelayedAdd(t.Result, 20))
        .ContinueWith(t => UpdateText(t.Result),
            TaskScheduler.FromCurrentSynchronizationContext())
        .ContinueWith(t => DelayedAdd(t.Result, 30))
        .ContinueWith(t => UpdateText(t.Result),
            TaskScheduler.FromCurrentSynchronizationContext())
        .ContinueWith(t => DelayedAdd(t.Result, 50))
        .ContinueWith(t => UpdateText(t.Result),
            TaskScheduler.FromCurrentSynchronizationContext()); 
        }
        private int UpdateText(int i)
        {
            textBox1.Text = i.ToString();
            return i;
        }
        private int DelayedAdd(int a, int b)
        {
            Thread.Sleep(500);
            return a + b;
        }

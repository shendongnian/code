    private void button1_Click(object sender, EventArgs e)
    {
        var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        Task.Factory.StartNew(() => AddRandomNumbers(uiScheduler));
    }
    private async Task AddRandomNumbers(TaskScheduler uiScheduler)
    {
        var r = new Random();
        for (int i = 0; i < 1000; i++)
        {
            await Task.Factory.StartNew(
                () => textBox1.Text = r.Next(0, 1000).ToString(), 
                CancellationToken.None, 
                TaskCreationOptions.None,
                uiScheduler);
   
                Thread.Sleep(1000);
        }
    }

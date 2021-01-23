    void button_Click(object sender, EventArgs e)
    {
        button.Enabled = false;
        Task.Factory.StartNew(() =>
        {
            //long-running stuff
        }).ContinueWith((result) =>
        {
            button.Enabled = true;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

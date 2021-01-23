    void button_Click(object sender, EventArgs e)
    {
        button.Enabled = false;
        IAsyncResult asyncResult = foo(...);
        Task.Factory.FromAsync(asyncResult, (result) =>
        {
            button.Enabled = true;
        }, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }

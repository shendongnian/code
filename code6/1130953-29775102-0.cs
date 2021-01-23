    var task = Task.Factory.StartNew(TestThread);
    task.ContinueWith(parent => 
    {
        if(parent.Exception != null)
            MessageBox.Show("Done.");
        else
            MessageBox.Show("Exception occurred.");
    }, TaskScheduler.FromCurrentSynchronizationContext());

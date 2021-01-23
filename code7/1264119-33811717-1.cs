    Progress<int> MyProgressObject { get; set; }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MyProgressObject = new Progress<int>(ProgressAction);
        ThreadPool.QueueUserWorkItem(TimeConsumingTask);
    }
    public void TimeConsumingTask(object state)
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(100);
            MyProgressBar.Dispatcher.Invoke(() => ProgressAction(i));
        }
    }
    public void ProgressAction(int progress)
    {
        MyProgressBar.Value = progress;
    }
 

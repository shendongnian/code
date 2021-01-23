    private void button_Click(object sender, RoutedEventArgs e)
    {
            var task = Task.Factory.tartNew(() => {
                                   NativeMethods.LongRunningMethod(10);});
        Task.Factory.StartNew(() =>
        {
            while (!task.IsCompleted)
            {
                Dispatcher.Invoke(() =>
                {
                    var val = NativeMethods.GetProgressUpdate();
                    ProgressBarMain.Value = val;
                    Thread.Sleep(100);
                });
            }
        });
    }

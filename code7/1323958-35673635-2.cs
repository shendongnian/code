    private void button_Click(object sender, RoutedEventArgs e)
    {
        Task task = Task.Run(() => aNewMethod());  // will call aNewMethod on the thread pool
    }
    private void aNewMethod()
    {
        double progressValue = 0;
        Dispatcher.Invoke(() => progressValue = progress.Value);
        if (progressValue == 0)
        {
            Thread.Sleep(3000); // still executes on the threadpool (see above), so not blocking UI
            Dispatcher.Invoke(() => progress.Value = 100 );  // call the dispatcher to access UI
        }
    }

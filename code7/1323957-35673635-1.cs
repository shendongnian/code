    private async void button_Click(object sender, RoutedEventArgs e)
    {
        Task task = Task.Run(() => aNewMethod());  // will call aNewMethod on the thread pool
        await task;
    }
    private void aNewMethod()
    {
            Thread.Sleep(3000); // still executes on the threadpool (see above), so not blocking UI
            Dispatcher.BeginInvoke((Action)delegate { progress.Value = 100 });  // call the dispatcher to access UI
     }

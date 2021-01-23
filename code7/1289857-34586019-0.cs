    public async void buttonAnswer_Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(() =>
        {
            //Your heavy processing here. Runs in threadpool thread
        });
        MessageBox.Show("Test..");//This runs in UI thread.
    }

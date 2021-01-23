    private void PageLoaded(object sender, RoutedEventArgs e)
    {
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
        {
            var wait = new PleaseWait("My title", "My Message", () => FillDataGrid());
            wait.ShowDialog();
            Dispatcher.Run();
        }));
    }
    

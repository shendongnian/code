    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.Enabled = false;
        await Task.Run(() =>
        {
            .. long running task here will not block UI
        });
        button.Enabled = true;
    }

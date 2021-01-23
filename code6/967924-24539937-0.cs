    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await DoSomethingAsync();
    }
    
    public async Task DoSomethingAsync()
    {
        await Task.Delay(2000);
    }

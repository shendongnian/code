    private async void button_Click(object sender, RoutedEventArgs e)
    {
        await Authenticate(); // Stuff happens
    }
    Task Authenticate()
    {
        return _authModule.Authenticate();
    }

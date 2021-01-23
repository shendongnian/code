    private void Show(string message, Dictionary<string, Action> commands)
    {
        // Code in ShowAsync is moved here
    }
    
    public Task ShowAsync(string message, Dictionary<string, Action> commands)
    {
        return Task.Run(() => Show(message, commands));
    }

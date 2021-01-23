    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string player1;
        NavigationContext.QueryString.TryGetValue("player1", out player1);
        string player2;
        NavigationContext.QueryString.TryGetValue("player2", out player2);
    }

    public IEnumerator SetupMainScreen(ParseUser user, Action<GameScore> callback)
    {
        
        
        var query = ParseObject.GetQuery("GameScore").WhereEqualTo("playerName", user.Username).FirstOrDefaultAsync();
        while (!query.IsCompleted)
        {
            yield return null;
        }
        if (query.IsFaulted || query.IsCanceled)
        {
            Debug.Log("Getting of GameScores faulted or cancelled...");
        }
        else
        {
            var obj = query.Result;
            if (obj != null)
                callback(new GameScore(obj.Get<int>("cash"),obj.Get<string>("playerName"),obj.Get<int>("HighestCash"),obj.Get<int>("GamesPlayed")));
        }
    }
    public void DealWithResults(GameScore gs)
    {
        WelcomeText.text = "Welcome, " + gs.Username + "\n" +
                       "Cash: $" + gs.Cash + "\n" +
                       "Highest Cash: $" + gs.HighestCash + "\n" +
                       "Games Played: " + gs.GamesPlayed;
    }

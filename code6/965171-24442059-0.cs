    public IEnumerator GameOver()
    {
        var gameHistory = new ParseObject("GameHistory");
        gameHistory["score"] = score;
        gameHistory["player"] = ParseUser.CurrentUser;
     
        var saveTask = gameHistory.SaveAsync();
        while (!saveTask.IsCompleted) yield return null;
     
        // When the coroutine reaches this point, the save will be complete
     
        var historyQuery = new ParseQuery<ParseObject>("GameHistory")
            .WhereEqualTo("player", ParseUser.CurrentUser)
            .OrderByDescending("createdAt");
     
        var queryTask = historyQuery.FindAsync();
        while (!queryTask.IsCompleted) yield return null;
     
        // The task is complete, so we can simply check for its result to get
        // the current player's game history
        var history = queryTask.Result;
    }

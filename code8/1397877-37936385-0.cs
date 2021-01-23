    public override void DisplayScore()
    {
        var scores = PlayerScores.OrderByDescending(s => s.Value).Take(5);
        foreach (var kvp in scores)
        {
            foreach (var player in PlayerList.Values)
            {
                SendMessage(MessageLocation, "My text");
            }
        }
    }

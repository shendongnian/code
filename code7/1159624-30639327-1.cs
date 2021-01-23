    LiveLeagues data = JsonConvert.DeserializeObject<LiveLeagues>(responseBody);
    foreach (var game in data.Games)
    {
      foreach (var players in game.Players)
      {
        listView1.Items.Add(players.Name);
      }
    }
    

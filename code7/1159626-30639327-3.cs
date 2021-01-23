    var data = JsonConvert.DeserializeObject<ResponseData>(responseBody);
    foreach (var game in data.Result.Games)
    {
      foreach (var players in game.Players)
      {
        listView1.Items.Add(players.Name);
      }
    }
    

    var players = new List<Player>();
    
    dynamic dObject = JObject.Parse(JSON);
    
    foreach (var property in dObject.players) {
        var player = property.Value;
    
        var playerModel = new Player {
            Name = player.name,
            Tag = player.tag,
            Rank = player.rank
        };
    
        players.Add(playerModel);
    }

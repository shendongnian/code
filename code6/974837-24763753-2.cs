    var players = db.Select<Player>(q => q.ClientId == request.ClientId);
    if (request.IsWinner != null)
    {
        players = request.IsWinner.Value
          ? players.Where(x => x.WinHistory.Any(y => y.GameId == game.Id)).ToList()
          : players.Where(x => x.WinHistory.Any().ToList()
    }
    else
    {
        players = players.Where(x => x.WinHistory.IsEmpty());
    }

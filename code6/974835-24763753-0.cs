    if (request.Winner == true)
    {
        q.Join<WinHistory>(); //uses implicit reference convention
        if (game != null)
            q.And<WinHistory>(w => w.GameId = game.Id);
    }
    else
    {
        q.LeftJoin<WinHistory>()
         .And<WinHistory>(w => w.Id == null);
    }
    var players = db.Select(q);

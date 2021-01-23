    foreach (DataRow d in DataTableGames.Rows)
    {
        Games g = new Games();
        g.ID = d.Field<int>("ID");
        g.GameName = d.Field<string>("Game");
        g.ServerLocation = d.Field<string>("ServerLocat");
        g.IP = d.Field<string>("iP");
        Game.Add(g);
    }

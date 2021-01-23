    Program.playerList.Sort(new PlayersByPointsComparer());
    // or
    Program.playerList.Sort((a, b) => (a.Points - b.Points));
    // or
    Program.OrderBy(a => a.Points).ToList();

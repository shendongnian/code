    // Group each player by the Team property and then associate the
    // team name to the total points for that team
    var teams = playerList.players.GroupBy(p => p.Team)
                                  .Select(t => new { Team = t.Key,Points = t.Sum(p => p.Points)});
    // Loop through your teams here
    foreach(var team in teams)
    {
        Console.WriteLine($"{team.Team}: {team.Points}");
    }

    List<Team> teams = new List<Team>();
    foreach (var record in players)
    {
        Team team = teams.SingleOrDefault(q=>q.Name == record.team);
        
        if(team == null)
        {
             team = new Team();
             team.Name = record.team;
             team.Players = new List<string>();
             team.Players.Add(record.player);
        }
        else
        {
            team.Players.Add(record.player);
        }       
    }

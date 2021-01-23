    using (var sportContext = new Sport())
    {
        var season2016 = sportContext.Seasons.First();
    
        var homeTeam = sportContext.Teams.Where(w => w.Name == "Leicester City").First();
        var awayTeam = sportContext.Teams.Where(w => w.Name == "Arsenal").First();
    
        Game game = new Game { HomeTeam = homeTeam , AwayTeam = awayTeam, Season = season2016 };
    
        //Populate the SeasonTeams Table
        var teamList = season2016.Teams.ToList();
        teamList.Add(homeTeam);
        teamList.Add(awayTeam);
    
        season2016.Teams = (teamList);
    
        sportContext.Games.Add(game);
        sportContext.SaveChanges();
    
        var season = sportContext.Seasons.First();
    
        var seasons = sportContext.Entry(season).Collection(c => c.Teams).Query();
                    
        foreach (Team team in seasons)
        {
            Console.WriteLine(team.Name);
        }
    }

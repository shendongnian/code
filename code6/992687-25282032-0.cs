    // Ensure lazy loading is turned off
    context.Configuration.LazyLoadingEnabled = false;
    
    // load the team
    var team = context.Teams.Find(teamId);
    
    // explicitly load the team records for the current season
    context.Entry(team)
        .Collection(t => t.TeamRecords)
        .Query()
        .Where(r => r.SeasonId == currentSeasonId)
        .Load();

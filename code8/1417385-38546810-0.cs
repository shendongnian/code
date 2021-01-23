    List<Team> teams = new List<Team>
    {
        new Team {Name = "Italy"},
        new Team {Name = "France"},
        new Team {Name = "Italy"}
    };
    var distinctList = teams.Select(team => team.Name)
                            .Distinct()
                            .Select(team => new Team {Name = team})
                            .OrderBy(team => team.Name)
                            .ToList();

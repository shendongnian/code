    private static Random _rnd = new Random();
    private static Team GetAndRemoveRandomTeam(List<Team> allTeams)
    {
        int randomIndex = _rnd.Next(allTeams.Count);
        Team randomTeam = allTeams[randomIndex];
        allTeams.RemoveAt(randomIndex);
        return randomTeam;
    }
    public static List<List<Team>> GenerateGroups(List<Team> teams, int amount)
    {
        int teamCount = (int) teams.Count/amount;
        List<Team> allteams = teams.ToList(); // copy to be able to remove items
        if (teamCount == 0)
            return new List<List<Team>> {allteams};
        List<List<Team>> allTeamGroups = new List<List<Team>>();
        List<Team> thisTeam = new List<Team>();
        while (allteams.Count > 0)
        {
            if (thisTeam.Count == amount)
            {
                allTeamGroups.Add(thisTeam);
                thisTeam = new List<Team>();
            }
            thisTeam.Add(GetAndRemoveRandomTeam(allteams));
        }
        allTeamGroups.Add(thisTeam);
        return allTeamGroups;
    }

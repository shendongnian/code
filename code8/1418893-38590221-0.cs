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
        List<List<Team>> result = Enumerable.Range(0, teamCount)
            .Select(t => Enumerable
                .Range(0, amount)
                .Select(i => GetAndRemoveRandomTeam(allteams))
                .ToList())
            .ToList();
        int teamsRemaining = allteams.Count; // not yet removed
        if (teamsRemaining > 0)
        {
            result.Add(Enumerable
                .Range(0, teamsRemaining)
                .Select(i => GetAndRemoveRandomTeam(allteams))
                .ToList());
        }
        return result;
    }

    public void addTeam(Team team, String sport)
    {
        // Add the team to the correct sport
        Teams.Add(team);
        this.SaveChanges();
    }

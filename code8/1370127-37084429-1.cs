    public void addTeam(Team team, String sport)
    {
        // Add the team to the correct sport
        Teams.Add(team);
        foreach(var user in team.Users)
        {
            this.Entry(user).EntityState = EntityState.Unchanged;
        }
        this.SaveChanges();
    }

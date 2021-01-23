    public IHttpActionResult PostNewTeam(Team team)
    {
        teams.Add(team);
        // Console.WriteLine("Post Team: " + team.ToString());
        return this.StatusCode(HttpStatusCode.Created);
    }

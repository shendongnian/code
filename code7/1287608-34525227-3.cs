    public ActionResult ViewAllPlayers(Guid id)
    {
        var team = db.Teams.Include(t => t.Players).Single(t => t.Id == id);
        TeamViewModel teamView = new TeamViewModel
        {
            TeamName = team.TeamName,
            Coach = team.Coach,
            Conference = team.Conference,
            Player = new List<PlayerModel>(team.Players)
        };
    
        return View(teamView);
    }

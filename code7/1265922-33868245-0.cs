    var team = new Team()
    {
        -- populate fields
    };
    var user = new Team_User()
    {
        -- populate fields
    };
    team.Team_Users.Add(user);
    dbContext.Teams.Add(team);
    dbContext.SaveChanges();

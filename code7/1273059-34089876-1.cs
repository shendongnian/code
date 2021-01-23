    // this is wrong, we do not provide inverse relation
    var team = new Team { ... };
    var p1 = new Person { FirstName = "Mark", PersonType = PersonType.Player };
    var p2 = new Person { FirstName = "Karl", PersonType = PersonType.Player };
    // the inverse relation is a MUST
    p1.Team = team;
    p2.Team = team;
    // this will do the cascade
    team.Players.Add(p1);
    team.Players.Add(p2);
    // now only team could be saved, the rest will be done by cascades
    session.Save(team);

        foreach (var team in distinctTeams)
        {
            var t = team;
            var roles = teamsRoles.Where(x => x.TeamId ==team.Id).Select(y => y.Role);
            tRoles.Add(new TeamRoles { Team=t, Roles=roles }); //need this  <====
         }

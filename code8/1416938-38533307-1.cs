    playerholder = players.GroupJoin(db.TeamAssignments, player => player.PlayerID, assignment => assignment.PlayerID, (player, assignment) => new
            {
                PlayerID = player.PlayerID,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Rating = player.Rating,
                NameLeague = assignment.Where(m => m.SeasonID == seasonId).Join(db.Teams, assign => assign.TeamID, team => team.TeamID, (assign, team) => new
                {
                    League = team.League,
                    Name = team.Name
                }).Where(m => m.League == league)
            }).Select(m => new PlayerListItem_PDMI
            {
                PlayerID = m.PlayerID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Rating = m.Rating,
                Assigned = m.NameLeague.Any(),
                TeamName = (m.NameLeague.Any() ? m.NameLeague.First().Name : "Not Assigned")
            }).ToList();

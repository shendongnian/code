    players.Join(db.TeamAssignments, player => player.PlayerID, team => team.PlayerID, (player, team) => new
                {
                    PlayerID = player.PlayerID,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Rating = player.Rating,
                    SeasonID = team.SeasonID,
                    TeamID = team.TeamID
                })
                .Join(db.Teams, playerassignment => playerassignment.TeamID, team => team.TeamID, (playerassignment, team) => new
                {
                    PlayerID = playerassignment.PlayerID,
                    FirstName = playerassignment.FirstName,
                    LastName = playerassignment.LastName,
                    Rating = playerassignment.Rating,
                    SeasonID = playerassignment.SeasonID,
                    League = team.League,
                    TeamName = team.Name
                })
                .Where(m => m.League == league && m.SeasonID == seasonId)
                .Select(m => new PlayerListItem_PDMI
                {
                    PlayerID = m.PlayerID,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Rating = m.Rating,
                    TeamName = m.TeamName
                }).ToList();

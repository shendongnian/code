    playerholder = from m in players
               let team = m.TeamAssignments.FirstOrDefault(n => n.Team.League == league && n.SeasonID == SeasonID)
               select new PlayerListItem_PDMI
               {
                PlayerID = m.PlayerID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Rating = m.Rating,
                Assigned = team != null,
                TeamName = team != null ? team.Name : "Not Assigned")
            }).ToList();

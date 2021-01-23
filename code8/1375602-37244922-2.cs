    conferences = allTeams.GroupBy(t => new { t.Conference, t.ConferenceEmail })
                   .Select(g => new ConferenceData {
                       Conference = g.Key.Conference,
                       ConferenceEmail = g.Key.ConferenceEmail,
                       Teams = g.Select(t => t.Team).ToList()
                   }).Tolist();

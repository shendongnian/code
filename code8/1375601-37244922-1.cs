    var conferences = (from t in allTeams
                      group t by new { t.Conference, t.ConferenceEmail } into g
                      select new ConferenceData {
                          Conference = g.Key.Conference,
                          ConferenceEmail = g.Key.ConferenceEmail,
                          Teams = g.Select(t => t.Team).ToList()
                      }).Tolist();

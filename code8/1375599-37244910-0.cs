    var conferences = allTeams.GroupBy(t => t.Conference)
                              .Select(grp => new ConferenceData
                                             {
                                                 Conference = grp.Key,
                                                 ConferenceEmail = grp.First().ConferenceEmail,
                                                 Teams = grp.Select(x => x.Team).ToList()
                                             })
                              .ToList();

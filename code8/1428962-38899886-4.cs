    //assuming allTeamNamesAndStatuses is a cross joing of all 'CurrentStatus' and 'TeamNames'
    var teamStatusCounts = models.GroupBy(x => new { x.CurrentStatus, x.TeamName })
                                 .Select(g => new { g.Key, Count = g.Count() })
                                 .ToList();
    
    var missingTeamsAndStatuses = allTeamNamesAndStatuses
                       .Where(a=>
                          !teamStatusCounts.Any(b=>
                              b.Key.CurrentStatus == a.CurrentStatus 
                              && b.Key.TeamName == a.TeamName))
                       .Select(a=>new { 
                            Key = new {  a.CurrentStatus, a.TeamName  }, 
                            Count = 0 
                       });
    teamStatusCounts.AddRange(emptyGroups);

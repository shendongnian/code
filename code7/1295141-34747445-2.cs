    var audits = (from a in context.LogEntries
                 group a by a.CorrelationId into grp
                 let logentries = grp.OrderByDescending( g => g.TimeStamp)
                 select   new AuditTrail
                          {
                              CorrelationId = grp.Key,
                              FirstEvent = logentries.First().TimeStamp,
                              LogEntries = logentries.ToList()
                          }).OrderByDescending( at => at.FirstEvent);

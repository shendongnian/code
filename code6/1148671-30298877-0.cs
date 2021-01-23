    var result = testRuns.GroupBy(tr => tr.TestID)
                         .Select(t => new { 
                                           TestID = t.Key,
                                           Reports = t.Select(r => r.ReportID).ToList()
                                          });

    List<Issue> issues = // get Issues from wherever
    var sumTime = issues.SelectMany(issue => issue.Fields.WorkLogs)
                   .GroupBy(x => x.Author)
                   .Select( x => new
                   {
                        x.Key.Name, 
                        Amount = x.Sum(s => s.TimeSpentSeconds)
                   }
                   );

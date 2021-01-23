    var issues = new[]
    {
        new Issue { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(4) },
        new Issue { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(12) },
        new Issue { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) }
    };
    
    var theIssue =
        issues.OrderBy(issue => (issue.StartDate - issue.EndDate).TotalDays)
              .First();

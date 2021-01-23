    IEnumerable<Result> query = results.GroupBy(r => r.Id)
        .Select(g => new Result
        { 
            Id = g.Key, 
            Company = String.Join(", ", g.Select(r => r.Company)) 
        });
            

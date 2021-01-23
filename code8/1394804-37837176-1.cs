    var data = 
        new[] {
            new { A = 3, B = 3 },
            new { A = 2, B = 2 },
            new { A = 2, B = 2 },
            new { A = 1, B = 1 }
        };
    
    var groups = data.GroupBy(x => x); // works since we are using anonymous types that use value equality
    
    if(groups.Any(g => g.Count() > 1)
    {
       // throw exception
    }
    
    var result = groups.Select(g=>g.Key)
                       .OrderBy(x => x.A)
                       .ThenBy(x => x.B)
                       .ToList();

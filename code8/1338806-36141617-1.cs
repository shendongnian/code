    var results = (from p in Groups
                  group p by p.GroupName into g
                  select new { GroupName = g.Key, Total = g.Count 
                  }).Where(c=>c.Total>1).ToList();
    
    If(results.Count()>1)
    {
    
    }

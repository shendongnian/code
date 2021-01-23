    query.GroupBy(s => s.Country).Select(p => new 
      Result{
        Value = p.Key,
        Count = p.Count()
      }
    );

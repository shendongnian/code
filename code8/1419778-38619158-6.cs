      // Partition the query
      rows=rows
        .Skip(param.Start)
        .Take(param.Length)
        .AsEnumerable(); // Or place the AsEnumerable in the projection
    
      // Project the query
      var result=rows.Select(j => new DataTableRowViewModel

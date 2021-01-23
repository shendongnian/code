      // Partition the query
      var result1=rows
        .Skip(param.Start)
        .Take(param.Length)
        /* Selecting only the fields we need */
        .Select(j=> new {
          j.Id, 
          j.ArrivalDate,
          j.DueDate,
          j.Contact,
          j.Priority,
          j.JobType,
          j.SapDate
        })
        .AsEnumerable(); // Or place the AsEnumerable in the projection
    
      // Project the query
      var result=result1.Select(j => new DataTableRowViewModel

    public JsonResult IndexData(DTParameterViewModel param)
    {
      // Start with the base query
      var rows = jobs.AsQueryable();
    
      // Order the query
      var first=true;
      foreach(DTOrder order in param.Order)
      {
        switch(order.Column)
        {
          case 0:
            if (first)
            {
              rows=(order.Dir=="asc")?rows.OrderBy(r=>r.Id):rows.OrderByDescending(r=>r.Id);
            } else {
              rows=(order.Dir=="asc")?rows.ThenBy(r=>r.Id):rows.ThenByDescending(r=>r.Id);
            }
            break;
          case 1:
            ...
        }
        first=false;
      }
    
      // Partition the query
      rows=rows
        .Skip(param.Start)
        .Take(param.Length)
        .AsEnumerable(); // Or place the AsEnumerable in the projection
    
      // Project the query
      var result=rows.Select(j => new DataTableRowViewModel
        {
          Id = j.Id,
          ArrivalDate = j.ArrivalDate.ToString(Constants.DATE_FORMAT),
          DueDate = j.DueDate?.ToString(Constants.DATE_TIME_FORMAT),
          Contact = j.Contact,
          Priority = j.Priority.GetDisplayName(),
          JobType = j.JobType.GetDisplayName(),
          SapDate = j.SapDate.ToString()
        });
    
       return result;
    }

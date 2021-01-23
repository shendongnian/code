    var first=true;
    foreach(DTOrder order in param.Order)
    {
      switch(order.Column)
      {
        case 0:
          if (first)
          {
            rows=(order.Dir=="asc")rows.OrderBy(r=>r.Id):rows.OrderByDescending(r=>r.Id);
          } else {
            rows=(order.Dir=="asc")rows.ThenBy(r=>r.Id):rows.ThenByDescending(r=>r.Id);
          }
          break;
        case 2:
          ...
      }
      first=false;
    }

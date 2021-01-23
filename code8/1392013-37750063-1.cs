           var query = _dataContext.Job          
    
           if (direction == "PickUp")
           {
              query = query
                     .Where(j => j.Departure.DateTime >= startDate && j.Departure.DateTime <= endDate).Select(j => new DispatchDashboardItem()
                     {
                          JobId = j.Id,
                          Direction = "PickUp",
                          CustomerName = j.Driver.Name,
                          Vehicle = j.Vehicle,
                          Location = j.Departure.MeetingLocation.Name,
                          DateTime = j.Departure.DateTime,
                    });
           }
           else
           {
              query = query
                      .Where(j => j.Return.DateTime >= startDate && j.Return.DateTime <= endDate).Select(j => new DispatchDashboardItem()
                      {
                            JobId = j.Id,
                            Direction = direction,
                            CustomerName = j.Driver.Name,
                            Vehicle = j.Vehicle,
                            Location = j.Return.MeetingLocation.Name,
                            DateTime = j.Return.DateTime,
                       });
           }
           query = query.ToList(); // execute SQL

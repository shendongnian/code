           var query = _dataContext.Job          
    
           if (direction == "PickUp")
           {
              query = query.Where(j => j.Departure.DateTime >= startDate && j.Departure.DateTime <= endDate)
           }
           else
           {
              query = query.Where(j => j.Return.DateTime >= startDate && j.Return.DateTime <= endDate)
           }
           query = query.Select(j => new DispatchDashboardItem()
           {
              JobId = j.Id,
              Direction = direction,
              CustomerName = j.Driver.Name,
              Vehicle = j.Vehicle,
              Location = j.Return.MeetingLocation.Name,
              DateTime = j.Return.DateTime,
           });

    public static IQueryable<DashboardItem> SelectDashboardItem(this IQueryable<Job> query, 
                string direction, 
                Expression<Func<Job, MeetingDetail>> location)
        {
          return query.AsExpandable()
            .Select(j => new DashboardItem()
            {
                JobId = j.Id,
                Direction = direction,
                CustomerName = j.Driver.Name,
                Vehicle = j.Vehicle,
                // This works without using the func
                Location = location.Invoke(j).MeetingLocation.Name,
                DateTime = location.Invoke(j).DateTime,                    
            });
        }

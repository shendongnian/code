       public IEnumerable<TimesheetModel> FilterByUserId(IEnumerable<TimesheetModel> obj, int FilterUserId)
        {
             var query = (from list in obj.Where(z=>z.List.Any(u=>u.UserId==FilterUserId))
                          select new TimesheetModel
                          {
                              TaskDate = list.TaskDate,
                              List = list.List.Where(o=> o.UserId.Equals(FilterUserId)).FirstOrDefault()
                          }).ToList();
        
             return query;
        }

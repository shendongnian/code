       public IEnumerable<TimesheetModel> FilterByUserId(IEnumerable<TimesheetModel> obj, int FilterUserId)
        {
             var query = (from list in obj.Where(x => x.List.Where(o=> o.UserId.Equals(FilterUserId)))
                          select new TimesheetModel
                          {
                              TaskDate = list.TaskDate,
                              List = list.List
                          }).ToList();
        
             return query;
        }

     var query = (from list in obj.Where(x => x.List.Any(z => z.UserId.Equals(FilterUserId)))
                      select new TimesheetModel
                      {
                          TaskDate = list.TaskDate,
                          List = list.List
                      }).ToList(); 

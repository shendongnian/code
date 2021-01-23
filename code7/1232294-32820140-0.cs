     var query = (from list in obj.Where(x => x.List.Where(y => y.UserId.Equals(FilterUserId)))
                      select new TimesheetModel
                      {
                          TaskDate = list.TaskDate,
                          List = list.List
                      }).ToList();

    var result = (from j in Joints
                  join l in Lines on j.LineId equals l.Id
                  join f in FitUpDetails on j.Id equals f.JointId into g2
                  from y2 in g2.DefaultIfEmpty()
                  group new { j, l, y2 } by new { j.Id, l.LineName, j.JointName } into grouping
                  let maxFitById = grouping.Select(item => item.y2)
                                          .Where(item => item != null)
                                          .OrderByDescending(item => item.Id)
                  select new
                  {
                      Id = grouping.Key.Id,
                      LineName = grouping.Key.LineName,
                      JointName = grouping.Key.JointName,
                      FitUpdate = maxFitById.FirstOrDefault()?.FitUpdate,
                      State = maxFitById.FirstOrDefault()?.State
                  }).ToList();

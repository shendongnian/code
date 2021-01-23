    var newQuery = subjects.SelectMany(y => y.Data.Select(x=> new {x.Day,x.Time,y.Name }));
    var newQuery2 = newQuery.OrderBy(x=>x.Day).OrderBy(x=>x.Time).GroupBy(x => x.Day);
    var newQuery3 = newQuery2.Select(x => new Schedule.Day
                {
                    DayOfWeek = x.Key,
                    Subjects = x.Select(y => new Schedule.Subject
                    {
                        Time = y.Time,
                        Name = y.Name
                    }).ToList()
                });

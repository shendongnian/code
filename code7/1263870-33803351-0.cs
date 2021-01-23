            var result = subjects
                .SelectMany(s => s.Data.Select(x => new { s.Name, x.Day, x.Time }))
                .GroupBy(x => x.Day)
                .Select(g => new Schedule.Day
                    {
                        DayOfWeek = g.Key,
                        Subjects = g.Select(item => new Schedule.Subject
                            {
                                Name = item.Name,
                                Time = item.Time
                            })
                            .OrderBy(item => item.Time)
                            .ToList()
                    })
                    .OrderBy(gItem => gItem.DayOfWeek)
                .ToList();

    var ageStats = vModel
                   .GroupBy(l => new { Age = 10 * (l.Age / 10), l.GenderName })
                   .OrderBy(x => x.Key) //<-- this line
                   .Select(g => new
                                {
                                    Name = g.Key,
                                    Count = g.Select(l => l.Age).Count()
                                })
                   .ToList();

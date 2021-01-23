    var query = list.GroupBy(r => r.prop2)
                    .Select(grp => new
                    {
                        Key = grp.Key,
                        Count = grp.Count(),
                    })
                    .OrderByDescending(r => r.Count);

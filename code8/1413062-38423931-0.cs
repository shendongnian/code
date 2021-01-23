    var denseRanked = data.AsEnumerable()
                    .GroupBy(datum => datum.Field1)
                    .OrderBy(datum => datum.Key)
                    .Select((grp, index) => new
                    {
                        Items = grp,
                        Rank = ++index
                    })
                    .SelectMany(v => v.Items, (s, i) => new
                    {
                        Item = i,
                        Rank = s.Rank
                    }).ToList();

    var uniqueData = list.Select(x => new
                {
                    UniqueKey = x.Name + " " + x.Description,
                    Data = x,
                }).GroupBy(x => x.UniqueKey)
                    .Select(g => g.First().Data)
                    .ToList();

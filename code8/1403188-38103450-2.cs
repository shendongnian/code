    var objectBList = objectAList.GroupBy(a => a.Date)
              .Select(group => new ObjectB{
                   Date = group.Key,
                   Code1 = group.FirstOrDefault(g => g.Code == 1)?.Value ?? 0,
                   Code2 = group.FirstOrDefault(g => g.Code == 2)?.Value ?? 0,
                   Code3 = group.FirstOrDefault(g => g.Code == 3)?.Value ?? 0})
              .ToList();

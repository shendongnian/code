    result.GroupBy(i => new {i.Memberid, i.Name}).Select(g => new
              { 
                  Name = g.Key.Name,
                  Amount = g.Sum(x => double.Parse(x.Amount))
              }).ToList();

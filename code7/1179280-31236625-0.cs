    var aggdata = customItems.GroupBy(t => new { t.Name, t.TargetDate.Date })
              .ToDictionary(t => t.Key.Name, t => new {
                  Date = t.Key.Date,
                  Average = t.Average(x => x.Value),
                  Sum = t.Sum(x => x.Price)
              });

    Dictionary<DateTime,Dictionary<string,double>> result = 
                          data.SelectMany(x => x.Value, (key, obj) => new { key, obj })
                              .GroupBy(x => new { Date = x.key.Key.Date })
                              .Select(x => new
              {
                  Date = x.Key.Date,
                  Output = x.GroupBy(z => z.obj.Key)
                     .Select(t => new { Table = t.Key, Sum = t.Sum(m => m.obj.Value) })
                     .ToDictionary(d => d.Table, d => d.Sum)
              }).ToDictionary(x => x.Date, x=> x.Output);

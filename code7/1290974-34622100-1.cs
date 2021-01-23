    var dups = ListItems.GroupBy(i => new { i.Value, i.Code })
                        .Where(g => g.Count() > 1)
                        .Select(g => new 
                         { 
                            Length = g.Key.Value,
                            Label = g.Key.Code,
                            Count = g.Count()
                         });

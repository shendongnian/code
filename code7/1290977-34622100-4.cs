    var dups = ListItems.GroupBy(i => new { i.Value, i.Code })
                        .Select(g => new 
                         { 
                            Length = g.Key.Value,
                            Label = g.Key.Code,
                            Count = g.Count()
                         })
                        .Where(g => g.Count > 1);

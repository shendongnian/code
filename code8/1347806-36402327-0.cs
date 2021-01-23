    var duplicates = session.Query<SomeClass>()
                            .GroupBy(e => new { e.Var1, e.Var2, e.Var3 })
                            .Select(s => new { s.Key.Var1, s.Key.Var2, s.Key.Var3, Count = s.Count() })
                            .ToList()
                            .Where(g => g.Count > 1)
                            .Select(g => new SomeClass() { Var1 = g.Var1, Var2 = g.Var2, Var3 = g.Var3})
                            .ToList();

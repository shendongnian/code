    List<int> items1 = myList.Select(t => t.Item1).ToList();
    List<int> items2 = myList.Select(t => t.Item2).ToList();
    var q = db.Table.GroupBy(m => { m.ID, m.AnotherValue })
                    .Where(g => items1.Contains(g.Key.ID) && 
                                items2.Contains(g.Key.AnotherValue))
                    .SelectMany(g => g);

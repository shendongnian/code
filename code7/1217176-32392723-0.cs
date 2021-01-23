    int code = 0;  // initialize with any value
    var groupItems = MyList.GroupBy(g => g.Id)
        .Where(w => w.Any(a => a.Code == code)
        .Select(s => new
        {
            key = s.Key,
            items = s.OrderBy(o => o.Item1)
                        .ThenBy(t => t.Item2)
        })
        .OrderBy(o => o.Id)
        .SelectMany(sm => sm.Items);  // No ToList() here!
    MyList.Clear();
    code = 1;
    MyList.InsertRange(Mylist.Count, groupItems.ToList());
    code = 2;
    MyList.InsertRange(Mylist.Count, groupItems.ToList());

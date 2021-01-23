    var grouped = _values.GroupBy(k => k, v => v,
                           (k, v) => new { Name = k, Count = v.Count()}).ToList();
    foreach (var item in grouped)
    {
        var name = item.Name;
        var count = item.Count;
        //do something with the name and count now.
    }

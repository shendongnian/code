    var items = db1.Ranges
                     .Where(x => x.DeviceId == Id)
                     .OrderByDescending(x => x.DeviceTime)
                     .Select(x => x.Val1)
                     .ToList();
    // if list is a List<double>
    list.AddRange(items.Select(x => (double)x));
    // If you really need the foreach
    foreach(var value in items)
    {
        list.Add((double)value);
    }

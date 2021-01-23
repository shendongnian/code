    static Tuple<DateTime, DateTime> Parse(string line)
    {
        var a = line.Split()
                .Take(2)        // take the start and end times only
                .Select(p => 
                      DateTime.ParseExact(p, "H:m",
                                          CultureInfo.InvariantCulture))
                .ToArray();
        return Tuple.Create(a[0], a[1]);
    }

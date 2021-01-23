    var times = new List<TimeSpan>();
    double interval = 5;
    //TimeSpan start = TimeSpan.Parse("23:55");
    //TimeSpan end = TimeSpan.Parse("00:10");
    DateTime starting = new DateTime(2014, 1, 1, 23, 55, 0);
    DateTime ending = new DateTime(2014, 1, 2, 0, 10, 0);
    for (var ts = starting; ts <= ending; ts = ts.AddMinutes(interval))
    {
        times.Add(ts.TimeOfDay);
    }

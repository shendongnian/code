    var groupedByDay = dt.AsEnumerable().GroupBy(r => r.Field<string>("Day"));
    foreach (var day in groupedByDay)
    {
        var sumVisits = day.Select(r => r.Field<int>("Visits")).Sum();
        var sumMs = day.Select(r => r.Field<int>("M")).Sum();
        var sumFs = day.Select(r => r.Field<int>("F")).Sum();
        Console.WriteLine("{0}\t{1}\t{2}\t{3}", day.Key, sumVisits, sumMs, sumFs);
    }

    var results = watedTable.AsEnumerable()
        .GroupBy(row => row.Field<string>("Column B"))
        .Select(grp => new 
        { 
            Server = grp.Key, 
            UserCount = grp.Select(row => row.Field<string>("ColumnA")).Distinct().Count()
        });
    foreach(var r in results)
        Console.WriteLine(r.Server + " has " + r.UserCount + " users.");

        //selecting into an object for better readability and access
        var result = dt.AsEnumerable().Select(r => new
        {
            TimeStamp = r.Field<DateTime>("TimeStamp"),
            CurveID = r.Field<short>("CurveId"),
            Mid = r.Field<double>("Mid")
        })
        // ignoring rows with different curve ID than in the list
        .Where(item => ids.Contains(item.CurveID))
        // grouping by timestamp
        .GroupBy(item => item.TimeStamp)
        // selecting only groups that have all curve Ids
        .Where(g => g.Select(i=>i.CurveID).Distinct().Count() == ids.Count)
        // grouping the groups by date
        .GroupBy(g => g.Key.Date)
        .Select(g2 =>
        {
            // getting the first timestamp group by timestamp
            var min = g2.OrderBy(i => i.Key).First();
            // getting all the Mid values
            var values = min.Select(i => i.Mid).ToList();
            // returning the desired computation
            return new
            {
                TimeStamp = min.Key,
                Spread = spread(values),
                Power = power(values)
            };
        })
        .ToList();

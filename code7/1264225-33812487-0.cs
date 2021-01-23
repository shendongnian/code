    string[] arrayOne = { "One", "Two", "Three", "Three", "Three", "X" };
    string[] arrayTwo = { "One", "Two", "Three" };
    var query1 = arrayOne.GroupBy(r => r)
        .Select(grp => new
        {
            Value = grp.Key,
            Count = grp.Count(),
        });
    var query2 = arrayTwo.GroupBy(r => r)
        .Select(grp => new
        {
            Value = grp.Key,
            Count = grp.Count(),
        });
    var result = query1.Select(r => r.Value).Except(query2.Select(r => r.Value)).ToList();
    var matchedButdiffferentCount = from r1 in query1
        join r2 in query2 on r1.Value equals r2.Value
        where r1.Count > r2.Count
        select Enumerable.Repeat(r1.Value, r1.Count - r2.Count);
    result.AddRange(matchedButdiffferentCount.SelectMany(r=> r));

    IEnumerable<string[]> query2 = data.Where(row => row[0] == "1000200034")
        .GroupBy(row => new { FirstKey = row[0], SecondKey = row[1] })
        .Select(grp => new string[]
        {
            grp.Key.FirstKey,
            grp.Key.SecondKey,
            grp.Sum(a => int.Parse(a.ElementAt(3))).ToString(),
        });

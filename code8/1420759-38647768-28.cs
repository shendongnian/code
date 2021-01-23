    var points =
        from p in new[] { 2.1, 2.2, 4, 4.1, 8, 8.2 }
        group p by (int) p into avgs
        select avgs.Average();
    Console.WriteLine(String.Join(", ", points.Select(p => p.ToString())));
    Result: 2.15, 4.05, 8.1

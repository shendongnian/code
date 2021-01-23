    var points =
        from p in new[] { 2.1, 2.2, 2.6, 4, 4.2, 4.7, 4.8 }
        let intp = (double)((int)p)
        let grp = (p - intp < .5) ? intp : p
        group p by grp into avgs
        select avgs.Average();
    var averages = String.Join(", ", points.Select(p => p.ToString()));
    Console.WriteLine(averages);
    
    Result: 2.15, 2.6, 4.1, 4.7, 4.8    

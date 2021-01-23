    var group = sales.GroupBy(sale=>new { sale.Item1, sale.Item2 });
    foreach (var e in group)
    {
        Console.WriteLine(e.Key.Item1 + ", " + e.Key.Item2 + ", " + e.Sum(t=>t.Item3));
        foreach (var sale in e)
        {
            Console.WriteLine('\t' + sale.Item1 + ", " + sale.Item2 + ", " + sale.Item3);
         }
     }

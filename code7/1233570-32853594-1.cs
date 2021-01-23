    var grouped = list.GroupBy(g => g.A);
    var collapsed = grouped.SelectMany(g =>
    {
         if (g.Key == 2)
         {
             return g.Take(1);
         }
         return g;
    });

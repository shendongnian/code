    List<stats> stats = new List<stats>
    {
         new stats
         {
             Money = 100,
             income = 5
         },
         new stats
         {
             Money = 200,
             income = 10
         }
    };
    foreach (var item in stats)
    {
         Console.WriteLine(item.ToString());
    }

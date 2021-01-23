    List<stats> stats = new List<stats>
    {
         new stats
         {
             Money = 100,
             Income = 5
         },
         new stats
         {
             Money = 200,
             Income = 10
         }
    };
    foreach (var item in stats)
    {
         Console.WriteLine(item.ToString());
        //Or like this:
         Console.WriteLine("Money = {0} , Income = {1}", item.Money , item.Income);
        //Or with c#6
         Console.WriteLine($"Money = {item.Money}");
         Console.WriteLine($"Income = {item.Income}");
    }

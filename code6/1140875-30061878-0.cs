    var inner = datasource
                  .OrderByDesc(x => x.W)
                  .ThenBy(x => x.L)
                   // etc for all orders you need
                  .GroupBy(new { W = W, L = L, RW = RW, RL = RL, HP = HP, TB = TB })
                  .First(2);
    
    if (inner[0].Count > 1 || inner[1].Count[1] > 1)
    {
       Console.Writeline("1 "+inner[0].Count.ToString());
       Console.Writeline("2 "+inner[1].Count.ToString());
    }

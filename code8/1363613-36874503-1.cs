    private static void PrintResponse(MessageSet set)
    {
      var q = from x in set.Messages
              where x.FromProperty == "<YOUR BOTS APP ID HERE>"
              select x.Text;
    
      foreach (var str in q.ToList())
       {
          Console.WriteLine(">> " +str);
       }
    
    
    }

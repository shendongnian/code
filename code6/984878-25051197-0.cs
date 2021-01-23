    var groups = times.GroupBy(item => item.Value).ToList();
    
    foreach(var g in groups)
    {
      Console.WriteLine("Value = " + g.Key);
    
      foreach(var member in g)
      {
        Console.WriteLine("\tKey = " + member.Key);
      }
    }

      Console.Write("Enter integer numbers to sum up, separating them by comma"):
    
      int result = Console
        .ReadLine()
        .Split(',')
        .Select(item => int.Parse(item)) 
        .Sum();
    
      // test: 123, 45, 67 => 235
      Console.Write(result);
      Console.ReadKey();

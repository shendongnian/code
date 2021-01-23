      int total;
    
      Console.WriteLine("How Many ? (2-4)");
    
      while (true) {
        if (!int.TryParse(Console.ReadLine(), out total)) {
          Console.WriteLine("Invalid input. How many?");    
        else if ((total < 2) || (total > 4)) {
          Console.WriteLine("Invalid range. How many?");  
        else
          break;
      }

    checked { 
      int counter = 1;
      try {
        while (true) 
          counter *= 2;
        }
      catch (Exception) { // Actually, on integer overflow
        Console.WriteLine(counter);
        Console.ReadLine();
      }
    }

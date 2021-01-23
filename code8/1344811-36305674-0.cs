    int? GetIntegerFromUser()
    {
      string input = System.Console.ReadLine();
      int result;
      return int.TryParse(input, out result) ? result : default(int?);
    }

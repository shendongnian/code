    async static Task D4()
    {
      Console.Write("Enter the divisor: ");
      var n = int.Parse(Console.ReadLine());
      Console.WriteLine((24 / n).ToString());
      return; // May be removed, since it is implicit.
    }

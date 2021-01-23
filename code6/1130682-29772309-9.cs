    public static void Main(string[] args)
    {
      Precise A = 10;
      A /= 3;
      try
      {
        var test = (int)A;
      }
      catch(InvalidOperationException)
      {
        Console.Error.WriteLine("Invalid operation attempted");
      }
      A *= 6;
      int result = (int)A;
      Console.WriteLine(result);
      // Let's do 10 / 5 * 2 = 4 because it works but can't be pre-combined:
      Console.WriteLine(new Precise(10) / 5 * 2);
      // Let's do 10 / 5 * 2 - 6 + 4 == 2 to mix in addition and subtraction:
      Console.WriteLine(new Precise(10) / 5 * 2 - 6 + 4);
      Console.Read();
    }

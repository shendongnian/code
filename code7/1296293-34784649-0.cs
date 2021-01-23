    class Program
    {
      static void Main(string[] args)
      {
        var pr = new Program();
        f(pr);
        if (pr == null)
          Console.WriteLine("Can't happen");
        else
          Console.WriteLine("Always happen");
      }
      public static void f(Program prog)
      {
        prog = null;
      }
    }

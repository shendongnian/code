    public class B : A
    {
      public override void Do()
      {
        // Call the base version of Get explicitly
        var getBase = base.Get();
        Console.WriteLine(getBase);
        // Call the current implementation of Get
        var get = Get();
        Console.WriteLine(get);
      }
      public override string Get()
      {
        return "B";
      }
    }

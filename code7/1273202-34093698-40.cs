    public static void Maybe(int a, int b)
    {
      bool shouldJump = (a > b) == false;
      if (shouldJump) goto IL_0017;
      Console.WriteLine("Greater");
    IL_0017:
      Console.WriteLine("Done");
    }

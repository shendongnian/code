    class A
    {
      static A() { }
      protected static int i = 0;
      public static readonly int Item1 = i++;
      public static readonly int Item2 = i++;
      public static readonly int Item3 = i++;
    }
    class B : A
    {
      static B() { }
      public static readonly int Item4 = i++;
      public static readonly int Item5 = i++;
      public static readonly int Item6 = i++;
    }

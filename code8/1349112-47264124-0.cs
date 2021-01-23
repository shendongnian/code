    A.dll
      public enum Foo { A, B }
    
    B.dll
      public const NumberOfFoos = Enum.GetNames(typeof(Foo)).Length;
    
    // Compiles to:
    B.dll
      public const NumberOfFoos = 2;

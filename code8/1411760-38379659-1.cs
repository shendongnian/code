    void Main()
    {
      A a = default(A), b = default(A);
      
      a = b = new A { Number = 42 };
      a.Number = 10;
      
      Console.WriteLine(a); // 42
      Console.WriteLine(b); // 10
    }
    
    public struct A
    {
      public int Number;
    }

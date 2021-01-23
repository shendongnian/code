    class A
    {
      public int Number { get; set; }
    }
    
    class B : A
    {
      public new int Number
      {
        get { return base.Number; }
      }
    }
    B b = new B();
    A a = b;
    a.Number = 42;
    Console.WriteLine(b.Number); // == 42. Oops.

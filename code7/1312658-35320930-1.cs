    class Aa { }
  
    class Bb : Aa { }
  
    class Cc : Bb { }
  
    class Program
    {
      static void Main(string[] args)
      {
        BaseGetter<Aa> getter = new DerivedGetter<Bb, Aa>();
        Console.WriteLine("Type: " + getter.Get().GetType().Name);
        getter = new Derived2Getter<Cc, Bb, Aa>();
        Console.WriteLine("Type: " + getter.Get().GetType().Name);
      }
    }

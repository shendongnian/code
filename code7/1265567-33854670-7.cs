    namespace ConsoleApplication3
    {
      class Program
      {
        static void Main(string[] args)
        {
            new Consume<Imp1>();
            new Consume<Imp2>();
            new Consume<ImpN>();
        }
      }
      class Consume<T> where T : A, new() { public Consume() { new T(); } }
      interface A { }
      interface A1 : A { }
      class Imp1 : A { public Imp1() { System.Console.WriteLine("Imp1"); } }
      class Imp2 : A1 { public Imp2() { System.Console.WriteLine("Imp2"); } }
      class ImpN : A { public ImpN() { System.Console.WriteLine("ImpN"); } }
    }

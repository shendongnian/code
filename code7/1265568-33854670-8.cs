    namespace ConsoleApplication3
    {
      class Program
      {
        static void Main(string[] args)
        {
            Consume<Imp1>();
            Consume<Imp2>();
            Consume<ImpN>();
            System.Console.ReadLine();
        }
        private static void Consume<T>() where T : A, new() { new T(); }
      }
      interface A { }
      interface A1 : A { }
      class Imp1 : A { public Imp1() { System.Console.WriteLine("Imp1"); } }
      class Imp2 : A1 { public Imp2() { System.Console.WriteLine("Imp2"); } }
      class ImpN : A { public ImpN() { System.Console.WriteLine("ImpN"); } }
    }

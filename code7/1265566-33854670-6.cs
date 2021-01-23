    using System;
    namespace ConsoleApplication3
    {
      class Program
      {
        static void Main(string[] args)
        {
            Consume<Imp1>.ConsumeObject();
            Consume<Imp2>.ConsumeObject();
            Consume<ImpN>.ConsumeObject();
            Console.ReadLine();
        }
      }
      class Consume<T> where T : A, new()
      {
        static public void ConsumeObject()
        {
            new T();
        }
      }
      class ConsumeA<T> where T : A { }
      class ConsumeA1<T> where T : A1 { }
      interface A { }
      interface A1 : A { }
      class Imp1 : A  {   public Imp1() { Console.WriteLine("Imp1"); }      }
      class Imp2 : A1 {   public Imp2() { Console.WriteLine("Imp2"); }      }
      class ImpN : A  {   public ImpN() { Console.WriteLine("ImpN"); }      }
    }

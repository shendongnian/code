    using System;
    namespace ConsoleApplication3
    {
       class Program
       {
          static void Main(string[] args)
          {
            A obj = new Imp1();
            Consume(obj);
            obj = new Imp2();
            Consume(obj);
            obj = new ImpN();
            Consume(obj);
            Console.ReadLine();
          }
        
          static void Consume(A a)  { a.Consume();  }
      }
  
      interface A { void Consume(); }
      interface A1 : A { }
      class Imp1 : A  { public void Consume(){ Console.WriteLine("Imp1"); } }
      class Imp2 : A1 { public void Consume(){ Console.WriteLine("Imp2"); } }
      class ImpN : A  { public void Consume(){ Console.WriteLine("ImpN"); } }
     }

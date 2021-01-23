    using System;
    class A
    {
       public virtual void F() { Console.WriteLine("A.F"); }
    }
    class B: A
    {
       public override void F() { Console.WriteLine("B.F"); }
    }
    class C: B
    {
       new public virtual void F() { Console.WriteLine("C.F"); }
    }
    class D: C
    {
       public override void F() { Console.WriteLine("D.F"); }
    }
    class Test
    {
       static void Main() {
          D d = new D();
          A a = d;
          B b = d;
          C c = d;
          a.F();
          b.F();
          c.F();
          d.F();
       }
    } 

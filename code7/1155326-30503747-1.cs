    public class F
    {
        public virtual void f(long l, int q = 0) { Console.WriteLine("public virtual void F.f(long l, int q = 0)"); }
    }
    public class FDerived : F
    {
        public override void f(long l, int q) { Console.WriteLine("public override FDerived.f(long l, int q)"); }
    }
    // Doesn't compile: No overload for method 'f' takes 1 arguments
	new FDerived().f(5L);

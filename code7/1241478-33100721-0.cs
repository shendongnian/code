    public struct A {}
    public class B { }
    
    public class C
    {
         public A A { get; set; }
         public B B { get; set; }
    }
    
    C c = new C();
    Expression<Func<C, object>> expr1 = some => some.A; // Convert(some.A)
    Expression<Func<C, object>> expr2 = some => some.B; // some.B

    [KnownType(typeof(A))]
    [KnownType(typeof(B))]
    public class AorB
    {
        public int Id {get;set;}
    }
    public class A : AorB
    {
    }
    public class B : AorB
    {
    }

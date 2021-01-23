    public class A
    {
        public virtual B B { get; set; }
    }
    public class B
    {
        public virtual IList<A> As { get; set; }  // not needed
        public virtual C C { get; set; }
    }
    public class C
    {
        public virtual IList<B> Bs { get; set; }  // not needed
        public virtual string ColumnY { get; set; }
    }

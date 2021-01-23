    public class A
    {
        public virtual int Id { get; set; }
        public virtual string messageA { get; set; }
        public virtual IList<B> Bs { get; set; }
    }
    public class B
    {
        public virtual int Id { get; set; }
        public virtual string messageB { get; set; }
        public virtual IList<C> Cs { get; set; }
    }
    public class C
    {
        public virtual int Id { get; set; }
        public virtual string messageC { get; set; }
    }

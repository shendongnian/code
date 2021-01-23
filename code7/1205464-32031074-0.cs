    public class Foo
    {
        private string var1;
        private string var2;
        public Foo() { }
        public Foo(Foo otherFoo)
        {
            this.var1 = otherFoo.var1;
            this.var2 = otherFoo.var2;
        }
    }
    public class Bar : Foo
    {
        public int ID { get; set; }
        public Bar(Foo instance)
            : base(instance)
        {
        }
    }

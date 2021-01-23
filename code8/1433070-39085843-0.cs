    public abstract class Parent<C> where C : Child
    {
        public ImmutableList<C> Children { get; set; }
    }
    public abstract class Child
    {
    }

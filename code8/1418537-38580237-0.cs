    class Base
    {
        public virtual void Accept(Visitor visitor)
        {
            visitor.Visit(this); // This calls the Base overload.
        }
    }
    class Derived<T> : Base
    {
        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this); // this calls the Derived<T> overload.
        }
    }
    public class Visitor
    {
        public void Visit(Base @base)
        {
            ...
        }
        public void Visit<T>(Derived<T> derived)
        {
            ...
        }
    }

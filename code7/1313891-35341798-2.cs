    public class Foo : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

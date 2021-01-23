    public interface IVisitor
    {
        void Visit(MethodToken token) { /* */ }
        void Visit(OperatorToken token) { /* */ }
        void Visit(NameToken token) { /* */ }
    }
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
    public class MethodToken : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

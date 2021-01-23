    public abstract class Node
    {
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
    public interface IVisitor<T>
    {
        T Visit(And element);
        T Visit(Or element);
        T Visit(Equals element);
    }

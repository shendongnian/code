    public interface Visitor<T>
    {
        T Visit(OrNode node);
        T Visit(NotNode node);
        T Visit(AndNode node);
        T Visit(IdNode node);
    }
    public abstract class ANode
    {
        public List<ANode> Childs { get; }
        public abstract T Accept<T>(Visitor<T> visitor);
    }
    public class OrNode : ANode
    {
        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    public class NotNode : ANode
    {
        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    
    public class AndNode : ANode
    {
        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    
    public class IdNode : ANode
    {
        public bool Value;
        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }

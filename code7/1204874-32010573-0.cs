    public class Base
    {
        public virtual int sides { get { return 8; } }
    }
    
    public class Child : Base
    {
        public override int sides { get { return 10; } }
    }

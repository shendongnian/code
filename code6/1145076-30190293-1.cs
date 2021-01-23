    public class Based
    {
        public virtual string fun()
        {
            return "I am base";
        }
    }
    
    public class Derived : Based
    {
        public override string fun()
        {
            return "I am derived";
        }
    }

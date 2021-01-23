    public class Based
    {
        public virtual string fun()
        {
            return "I am based";
        }
    }
    
    public class Derived : Based
    {
        public override string fun()
        {
            return "I am dervid";
        }
    }

    public class First
    {
        public virtual string GetName()
        {
            return "First";
        }
    }
    public class Second : First
    {
        public override string GetName()
        {
            return "Second";
        }
    }

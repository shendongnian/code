    [AttributeUsage(AttributeTargets.Parameter)]
    public class SomeCoolAttribute : System.Attribute
    {
        public SomeCoolAttribute(int val)
        {
        }
    }
    class Test
    {
        public void Run([SomeCool(123)] string value)
        {
        }
    }

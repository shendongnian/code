    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PAttribute : Attribute
    {
        public int Weight { get; private set; }
        public PAttribute(int weight)
        {
            Weight = weight;
        }
    }

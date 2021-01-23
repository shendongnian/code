    [AttributeUsage(System.AttributeTargets.Struct)]
    public class MinMaxSizeAttribute : Attribute
    {
        public int MinVal { get; set;}
        public int MaxVal { get; set;}
        public MinMaxSizeAttribute()
        {
        }
    }

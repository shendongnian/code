    [AttributeUsage(AttributeTargets.Property)]
    public class MyRangeAttribute : RangeAttribute
    {
        public MyRangeAttribute(int minimum, string errorMessage) : base(minimum, DateTime.Now.Year)
        {
        }
    }

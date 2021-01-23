    public class MyMaxLengthAttribute : StringLengthAttribute
    {
        public MyMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = "{0} length should not be more than {2}"
        }
    }

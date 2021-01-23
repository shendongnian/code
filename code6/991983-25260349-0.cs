    public class MyMaxLengthAttribute : MaxLengthAttribute
    {
        public MyMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = Translations.Attribute.MAX_LENGTH;
        }
        // other ctors/members as needed
    }

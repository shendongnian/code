    public class CustomStringLength: ValidationAttribute
    {
        public CustomStringLength()
        {
        }
        public override bool IsValid(object value)
        {
            return (string)value.Length == MyClass.MyStaticProperty;
        }
    }

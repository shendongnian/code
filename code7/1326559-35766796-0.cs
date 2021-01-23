    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class IdentifierValidationAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public IdentifierValidationAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if(string.IsNullOrEmpty(stringValue))
                return false;
 
            var length = stringValue.Length;
            if(length > MaxLength || length < MinLength)
                return false;
            return true;
        }
    }

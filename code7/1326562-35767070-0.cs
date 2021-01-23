    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class GroupedValidationAttribute : ValidationAttribute
    {
        private ValidationAttribute[] _attributes = new ValidationAttribute[]
        {
            new RequiredAttribute(),
            new EmailAddressAttribute(),
            new StringLengthAttribute(6),
            new MinLengthAttribute(5),
            new CustomAAttribute(),
            new CustomBAttribute()
        };
    
        public GroupedValidationAttribute()
        { }
    
        public override bool IsValid(object value)
        {
            bool allTrue = true;
            foreach(var attr in _attributes)
                if (!attr.IsValid(value))
                    allTrue = false;
            return allTrue;
        }
    }

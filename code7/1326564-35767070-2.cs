    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class GroupedValidationAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly ValidationAttribute[] _attributes;
    
        public GroupedValidationAttribute(int minLength, int maxLength)
        { 
            _attributes = new ValidationAttribute[]
            {
                new RequiredAttribute(),
                new EmailAddressAttribute(),
                new StringLengthAttribute(maxLength),
                new MinLengthAttribute(minLength),
                new CustomAAttribute(),
                new CustomBAttribute()
            };
        }
    
        public override bool IsValid(object value)
        {
            return _attributes.All(a => a.IsValid(value));
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return _attributes
                .OfType<IClientValidatable>()
                .SelectMany(x => x.GetClientValidationRules(metadata, context));
        }
    }

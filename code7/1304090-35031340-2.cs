    public class RequiredIfAttribute : ValidationAttribute
    {
        private RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string Property { get; set; }
        public object Value { get; set; }
        public RequiredIfAttribute(string typeProperty) {
            Property = typeProperty;
        }
        public RequiredIfAttribute(string typeProperty, object value)
        {
            Property = typeProperty;
            Value = value;
        }
        public override bool IsValid(object value)
        {
            return _innerAttribute.IsValid(value);
        }
    }
    public class RequiredIfValidator : DataAnnotationsModelValidator<RequiredIfAttribute>
    {
        public RequiredIfValidator(ModelMetadata metadata, ControllerContext context, RequiredIfAttribute attribute) : base(metadata, context, attribute) { }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return base.GetClientValidationRules();
        }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            PropertyInfo field = Metadata.ContainerType.GetProperty(Attribute.Property);
            if (field != null) {
                var value = field.GetValue(container, null);
                
                if ((value != null && Attribute.Value == null) || (value != null && value.Equals(Attribute.Value))) {
                    if (!Attribute.IsValid(Metadata.Model)) {
                        yield return new ModelValidationResult { Message = ErrorMessage };
                    }
                }
            }
        }
    }

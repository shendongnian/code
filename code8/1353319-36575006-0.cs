    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CannotBeRedAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            var message = value as string;
            return message?.ToLower() == "red";
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ClientModelValidationContext context)
        {
            yield return new ModelClientValidationRule(
                "cannotbered",
                FormatErrorMessage(ErrorMessage));
        }
    }

    public class RequiredIfAttribute : RequiredAttribute
    {
        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        private string _DependentProperty;
        private object _TargetValue;
        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            this._DependentProperty = dependentProperty;
            this._TargetValue = targetValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Property info for the specified dependent property.
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this._DependentProperty, Flags);
            if (propertyTestedInfo == null)
                return new ValidationResult(string.Format("{0} needs to be exist in this object.", this._DependentProperty));
            // And its value
            var dependendValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            if (dependendValue == null)
                return new ValidationResult(string.Format("{0} needs to be populated.", this._DependentProperty));
            // If it meets the specified "If" predicate value
            if (dependendValue.Equals(this._TargetValue))
            {
                // Get the property being validated.
                var validatedProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName, Flags);
                if (validatedProperty != null)
                {
                    // Debug sanity check
                    AssertHasThisAttribute(validatedProperty);
                    // Get the property's value.
                    var validatedPropertyValue = validatedProperty.GetValue(validationContext.ObjectInstance, null);
                    // And check that is is not null
                    if (validatedPropertyValue != null)
                        return ValidationResult.Success;
                }
                // validation failed.
                return new ValidationResult(string.Empty);
            }
            // Must be ignored
            return ValidationResult.Success;
        }
        // Debug only sanity check.
        [Conditional("DEBUG")]
        private void AssertHasThisAttribute(PropertyInfo prop)
        {
            var attr = prop.GetCustomAttributes<RequiredIfAttribute>().FirstOrDefault();
            Debug.Assert(attr != null);
            Debug.Assert(attr._TargetValue == _TargetValue);
            Debug.Assert(attr._DependentProperty == _DependentProperty);
        }
    }

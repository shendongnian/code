    public IEnumerable<ValidationResult> Validate(object input)
    {
        return ValidateWithState(input, new HashSet<object>());
    }
    private IEnumerable<ValidationResult> ValidateWithState(object input, HashSet<object> traversedInputs)
    {
        if (input == null || traversedInputs.Contains(input))
        {
           return Enumerable.Empty<ValidationResult>();
        }
        var validationResults = new List<ValidationResult>();
        foreach (var prop in TypeDescriptor.GetProperties(input).Cast<PropertyDescriptor>())
        {
            foreach (var att in prop.Attributes.OfType<ValidationAttribute>())
            {
                if (!att.IsValid(prop.GetValue(input)))
                {
                    validationResults.Add(new ValidationResult(
                            att.FormatErrorMessage(string.Empty),
                            new[] { prop.Name }
                ));
            }
            traversedInputs.Add(input);
            if (prop.PropertyType.IsClass || prop.PropertyType.IsInterface))
            {
                validationResults.AddRange(ValidateWithState(prop.GetValue(input), traversedInputs));
            }
        }
        
        return validationResults;
    }

    public IEnumerable<ValidationResult> Validate(object input)
    {
        if (input == null) return Enumerable.Empty<ValidationResult>();
        var validationResults = new List<ValidationResult>();
        foreach (var prop in TypeDescriptor.GetProperties(input).Cast<PropertyDescriptor>())
        {
             // No need to do this for every attribute because
             // the attribute doesn't affect the the recursive validation.
             if (prop.PropertyType.IsClass))
             {
                 validationResults.AddRange(Validate(prop.GetValue(input)));
             }
            foreach (var att in prop.Attributes.OfType<ValidationAttribute>())
            {
                if (!att.IsValid(prop.GetValue(input)))
                {
                    validationResults.Add(new ValidationResult(
                            att.FormatErrorMessage(string.Empty),
                            new[] { prop.Name }
                ));
            }
        }
    }
    return validationResults;
}

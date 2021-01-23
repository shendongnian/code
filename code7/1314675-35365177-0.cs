    public static ValidationAttribute GetAttribute(Type entityType, string property, string errorMessage)
    {
       var attributes = typeof(entityType)
                       .GetProperty(property)
                       .GetCustomAttributes(false)
                       .OfType<ValidationAttribute>()
                       .ToArray();
       var attribute= attributes.FirstOrDefault(a => a.ErrorMessage == errorMessage);
       return attribute;
    } 

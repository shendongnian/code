    // NOTE: nameof() is a .NET 4.6 feature.  If you are using an older
    // version of .NET, you'll have to write the string yourself.
    MethodInfo method = GetType().GetMethod(nameof(TestValidate), typeof(string));
    // NOTE: it's on you to validate this and use the version with binding flags for
    // special cases like non-public and static methods
    ParameterInfo parameter = method.GetParameters().First();
    // This is shorthand: GetCustomAttributes returns object[], you'll have
    // convert that properly and reference your customAttributes later
    ValidationAttribute[] customAttributes = parameter.GetCustomAttributes(
            typeof(ValidationAttribute), true); // second parameter ignored
    // At this point you can handle the rest of your validation
    ValidationContext context = new ValidationContext(name);
    Validator.ValidateValue(name, context, customAttributes);
        return name;

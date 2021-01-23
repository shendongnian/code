    public static void Validate(MethodInfo method, params object[] values)
    {
        ValidationContext context = new ValidationContext(method.Name);
        ParameterInfo[] parameters = method.GetParameters();
        for(int i = 0; i < Math.Min(parameters.Length, values.Length); i++)
        {
            // This is shorthand: GetCustomAttributes returns object[], you'll have
            // convert that properly and reference your customAttributes later
            ValidationAttribute[] customAttributes = parameter[i].GetCustomAttributes(
                    typeof(ValidationAttribute), true); // second parameter ignored
            Validator.ValidateValue(values[i], context, customAttributes);
        }
    }

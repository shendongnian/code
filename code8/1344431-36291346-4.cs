    public static class AuthorizationHelpers
    {
        public static T GetValue<T>(this ActionExecutingContext filterContext, string Field)
        {
            if (Field != null)
            {
                // Get the value provider for the given field name
                var value = filterContext.Controller.ValueProvider.GetValue(Field);
    
                // If the value provider has an attemped value (value), proceed
                if (value != null && !string.IsNullOrEmpty(value.AttemptedValue))
                {
                    // Get the underlying type of the generic parameter and return the true type: [Nullable<
                    Type underType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
    
                    // Get the TypeConvert to change string (AttemptedValue) to `T`.
                    TypeConverter conv = TypeDescriptor.GetConverter(underType);
    
                    // Create an auxiliar variable that will contain the result.
                    T result = default(T);
    
                    // See if the converted can convert the AttemptedValue to `T`
                    if (conv.IsValid(value.AttemptedValue))
                        result = (T)conv.ConvertFrom(value.AttemptedValue); // Convert the value
    
                    return result;
                }
            }
    
            // Return the default of the generic type if the field name doesn't exist.
            return default(T);
        }
    
        public static void NoPermissions(ActionExecutingContext filterContext)
        {
            // Override the result so it returns another action (No permissions action)
            filterContext.Result = new RedirectResult("~/Error/NoPermissions");
        }
    }

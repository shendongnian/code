    public static GetMyEnumDisplayName(MyEnumType value)
    {
        var displayAttribute = value.GetType()
            .GetTypeInfo()
            .GetDeclaredField(result)
            .GetCustomAttribute(typeof(DisplayAttribute));
    
            if (displayAttribute != null)
            {
                var Name = ((DisplayAttribute)displayAttribute).Name;
            }
    }

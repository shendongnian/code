    // Indexed properties are not useful (or valid) for grabbing properties off an object.
    private static bool IsInterestingProperty(PropertyInfo property)
    {
        return property.GetIndexParameters().Length == 0 &&
            property.GetMethod != null &&
            property.GetMethod.IsPublic &&
            !property.GetMethod.IsStatic;
    }

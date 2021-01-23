    public static void IfNull(object value, Func<string> variableName)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Cannot be empty", variableName());
        }
    }

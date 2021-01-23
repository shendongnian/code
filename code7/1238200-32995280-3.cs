    public static string GetDisplayName<T>()
    {
        var displayName = typeof(T).GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;
    
        if (displayName != null)
            return displayName.DisplayName;
    
         return "";
    }

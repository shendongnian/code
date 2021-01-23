    public static bool IsValid<TStats>(TStats stats, decimal value)
    {
        if (Equals(stats, null))
            return false;
    
        // Get the 'Mean' property
        var propertyInfo = typeof(TStats).GetProperty("Mean");
      
        if (Equals(propertyInfo, null))
            return false;
    
        // Get
        var meanValue = propertyInfo.GetValue(stats, null) as decimal?;
    
        // ... do what ever you want with the meanValue
        return meanValue.HasValue && meanValue.Value == value;
    }

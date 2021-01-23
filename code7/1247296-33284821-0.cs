    // Default overload
    public static bool IsValid(object value) 
    { return false; }
    // If it's an array
    public static bool IsValid(Array value)
    {
        return value.Length > 0;
    }
    ...
    bool isValid = IsValid((dynamic)obj); // Will call the overload corresponding to type of obj

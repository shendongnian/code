    public static object MyConvert(String value, Type T)
    {
        if (T.IsEnum)
    	    return Enum.Parse(T, value, true);
    
        return Convert.ChangeType(value, T);
    }

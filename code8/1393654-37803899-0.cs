    [Flags]
    public enum ExternalSystemVersionEnum
    {
        System1_1 = 1,
        System2_1 = 2,
        System3_2 = 4,
        All = 7
    }
    
    var enumString = decimalValue.ToString("0.0", 
        CultureInfo.InvarantCulture).Replace('.', "_");
    
    var enumValue = (ExternalSystemVersionEnum)Enum.Parse(
        typeof(ExternalSystemVersionEnum), enumString);

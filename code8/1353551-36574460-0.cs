    public static KeyValuePair<string, List<KeyValueDataItem>> ConvertEnumWithDescription<T>() where T : struct, IConvertible
    {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Type given T must be an Enum");
            }
                                    
            var enumType = typeof(T).ToString().Split('.').Last();
            var type = typeof(T);
    
            var itemsList = Enum.GetValues(typeof(T))
                    .Cast<T>()
                    .Select(x => new KeyValueDataItem
                    {
                        Key = Convert.ToInt32(x),
                        Value = GetEnumDescription<T>(Enum.GetName(typeof(T), x))
                    })
                    .ToList();
                    
            var res = new KeyValuePair<string, List<KeyValueDataItem>>(
                enumType, itemsList);
            return res;
    
    }       
    
    public static string GetEnumDescription<T>(string enumValue)
    {
        var value = Enum.Parse(typeof(T), enumValue);
        FieldInfo fi = value.GetType().GetField(value.ToString());
    
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
        if (attributes.Length > 0)
            return attributes[0].Description;
        return value.ToString();
    }

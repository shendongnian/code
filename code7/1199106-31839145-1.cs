    public static string GetDescription(Enum value)
    {
        Type type = value.GetType();
        var values = Enum.GetValues(type);
        var setValues = new List<Enum>();
        foreach(var enumValue in values)
        {
            if (value.HasFlag((Enum)enumValue))
                setValues.Add((Enum)enumValue);
        }
        var stringList = new List<string>();
        foreach (var singleValue in setValues)
        {
            var name = Enum.GetName(type, singleValue);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        stringList.Add(attr.Description);
                    }
                }
            }
        }
        return string.Join(",", stringList.ToArray());
    }

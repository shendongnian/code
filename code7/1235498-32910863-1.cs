    public static string GetDisplayName(this Enum enumValue)
        {
    
            Type type = enumValue.GetType();
            string name = Enum.GetName(type, enumValue);
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
                        return attr.Description;
                    }
                }
            }
            return name;
        }

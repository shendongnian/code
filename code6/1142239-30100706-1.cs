    public string GetDescription(Type t)
    {
        System.ComponentModel.DescriptionAttribute attrib = t.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
    
        if (attrib != null)
            return attrib.Description;
    
        return string.Empty;
    }

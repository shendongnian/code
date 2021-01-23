    public static bool IsObsolete(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (ObsoleteAttribute[])
            fi.GetCustomAttributes(typeof(ObsoleteAttribute), false);
        return (attributes != null && attributes.Length > 0);
    }

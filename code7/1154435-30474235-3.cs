    public static string GetDescription(this object obj)
    {
            var fi = obj.GetType().GetField(obj.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            return obj.ToString();
    }

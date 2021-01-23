    public static class EnumExtension
    {
        public static string GetDescription(this Enum @enum)
        {
            FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes
                    (typeof (DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute) attrs[0]).Description;
            }
            return null;
        }
        public static IEnumerable<TEnum> GetAllValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }

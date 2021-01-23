    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
                return value.ToString();
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .OfType<DescriptionAttribute>()
                                 .SingleOrDefault();
            return attribute != null
                ? attribute.Description
                : value.ToString();
        }
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var attribute = (DisplayNameAttribute) value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DisplayNameAttribute)
                .FirstOrDefault();
            return attribute != null ? attribute.DisplayName : value.ToString();
        }
    }

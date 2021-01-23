    public static class EnumUtils
    {
        public static string GetDescription(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof (DescriptionAttribute), false);
            return (attributes.Length > 0) ? ((DescriptionAttribute) attributes[0]).Description : null;
        }
        public static Dictionary<TEnum, string> GetItemsWithDescrition<TEnum>()
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException("TEnum must be an enum type");
            }
            return Enum
                    .GetValues(enumType)
                    .Cast<TEnum>()
                    .ToDictionary(enumValue => enumValue, enumValue => GetDescription(enumValue as Enum));
        }
    }

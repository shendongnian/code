            public static string GetDescription<T>(this T enumerationValue)
            where T : struct, IConvertible
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            var memberInfo = type.GetMember(enumerationValue.ToString(CultureInfo.InvariantCulture));
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    // Pull out the description value
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            // If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString(CultureInfo.InvariantCulture);
        }

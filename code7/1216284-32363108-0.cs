    public enum CoolEnum {
        [Display(Name="Value 1")]
        Value1,
        [Display(Name="Value 2")]
        Value2,
    }
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name != null ? ((DisplayAttribute)attrs[0]).Name : enumValue; //TODO Null check
            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }
            return outString;
        }
    }

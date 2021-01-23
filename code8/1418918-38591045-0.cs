    public enum LogCategories
    {
        [Description("Audit Description")]
        Audit,
    }
    public static class DescriptionExtensions
    {
        public static string GetDescription<T, TType>(this T enumerationValue, TType attribute)
            where T : struct
            where TType : DescriptionAttribute
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
               
                if (attribute is DescriptionAttribute)
                {
                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }
                else
                {                   
                }                
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }

    namespace CSharpWPF
    {
        public class EnumHelper
        {
            public static IEnumerable<string> GetEnumDescriptions(Type enumType)
            {
                foreach (var item in Enum.GetNames(enumType))
                {
                    FieldInfo fi = enumType.GetField(item);
                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes != null && attributes.Length > 0)
                        yield return attributes[0].Description;
                    else
                        yield return item;
                }
            }
        }
    }

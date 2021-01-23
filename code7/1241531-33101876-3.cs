    public class EnumHelper
    {
        public static string GetDescription(Enum @enum)
        {
            if (@enum == null)
                return null;
            string description = @enum.ToString();
            try
            {
                FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    description = attributes[0].Description;
            }
            catch
            {
            }
            return description;
        }
    }

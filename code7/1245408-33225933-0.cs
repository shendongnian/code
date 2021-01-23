        public class Program
        {
            private static void Main(string[] args)
            {
                var name = "first_name";
                CustomFields customFields = EnumHelper<CustomFields>.GetValueFromName(name);
            }
        }
    
        public enum CustomFields
        {
            [Display(Name = "first_name")]
            FirstName = 1,
    
            [Display(Name = "last_name")]
            LastName = 2,
        }
    
        public static class EnumHelper<T>
        {
            public static T GetValueFromName(string name)
            {
                var type = typeof (T);
                if (!type.IsEnum) throw new InvalidOperationException();
    
                foreach (var field in type.GetFields())
                {
                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof (DisplayAttribute)) as DisplayAttribute;
                    if (attribute != null)
                    {
                        if (attribute.Name == name)
                        {
                            return (T) field.GetValue(null);
                        }
                    }
                    else
                    {
                        if (field.Name == name)
                            return (T) field.GetValue(null);
                    }
                }
    
                throw new ArgumentOutOfRangeException("name");
            }
        }

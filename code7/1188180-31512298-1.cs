    public static class StaticHelper
        {
            public static string GetDescriptionOfEnum(Enum value)
            {
                var type = value.GetType();
                if (!type.IsEnum) throw new ArgumentException(String.Format("Type '{0}' is not Enum", type));
    
                var members = type.GetMember(value.ToString());
                if (members.Length == 0) throw new ArgumentException(String.Format("Member '{0}' not found in type '{1}'", value, type.Name));
    
                var member = members[0];
                var attributes = member.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attributes.Length == 0) throw new ArgumentException(String.Format("'{0}.{1}' doesn't have DisplayAttribute", type.Name, value));
    
                var attribute = (System.ComponentModel.DataAnnotations.DisplayAttribute)attributes[0];
                return attribute.Description;
            }
        }

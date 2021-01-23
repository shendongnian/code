    public static string GetStringRepresentation(this Enum en)
            {
                Type type = en.GetType();
    
                MemberInfo[] memInfo = type.GetMember(en.ToString());
    
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(StringRepresentationAttribute), false);
    
                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((StringRepresentationAttribute)attrs[0]).StringRepresentation;
                    }
                }
    
                return en.ToString();
            }

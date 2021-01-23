    public static Dictionary<TEnum,string> ToDictionary<TEnum>(this TEnum obj)
          where TEnum : struct, IComparable, IFormattable, IConvertible
            {
    
                return (Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                    .Select(x =>
                        new
                        {
                            Enum = obj,
                            Description = x.AttributeValue<EnumDisplayNameAttribute>(d=>d.DisplayName)
                        }).ToDictionary(x=>x.Enum,x=>x.Description));
    
                
    
            }

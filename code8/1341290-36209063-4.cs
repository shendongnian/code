    public static Dictionary<int,string> ToDictionary<TEnum>(this TEnum obj)
          where TEnum : struct, IComparable, IFormattable, IConvertible
          {
    
             return (Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                    .Select(x =>
                        new
                        {
                            Text = Enum.GetName(typeof(TEnum), x),
                            Value = (Convert.ToInt32(x)),
                            Description = x.AttributeValue<EnumDisplayNameAttribute>(d=>d.DisplayName)
                        }).ToDictionary(x=>x.Value,x=>x.Description));
    
          }

    public static Dictionary<TEnum,string> ToDictionary<TEnum,TAttribute>(this TEnum obj,Func<TAttribute,string> func)
      where TEnum : struct, IComparable, IFormattable, IConvertible
      where TAttribute : Attribute
        {
            return (Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new
                    {
                        Value = (TEnum)(object)x,
                        Description = x.AttributeValue<TAttribute>(func)
                    }).ToDictionary(x=>x.Value,x=>x.Description));
            
        }

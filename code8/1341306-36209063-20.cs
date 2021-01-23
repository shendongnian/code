    public static Dictionary<TEnum,string> ToDictionary<TEnum,TAttribute>(this TEnum obj,Func<TAttribute,string> func)
      where TEnum : struct, IComparable, IFormattable, IConvertible
      where TAttribute : Attribute
        {
            return (Enum.GetValues(typeof(TEnum)).OfType<TEnum>()
                .Select(x =>
                    new
                    {
                        Value = x,
                        Description = x.AttributeValue<TEnum,TAttribute>(func)
                    }).ToDictionary(x=>x.Value,x=>x.Description));
            
        }

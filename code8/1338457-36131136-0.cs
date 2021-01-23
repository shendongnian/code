    public static TEnum GetValueFromAttribute<TEnum, TAttribute>
               (string text, Func<TAttribute, string> valueFunc) where TAttribute : Attribute
    { 
		var type = typeof(TEnum);
        if(!type.IsEnum) throw new InvalidOperationException();
        foreach(var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(TAttribute)) as TAttribute;
            if(attribute != null)
            {
                if(valueFunc.Invoke(attribute) == text)
                    return (TEnum)field.GetValue(null);
            }
            else
            {
                if(field.Name == text)
                    return (TEnum)field.GetValue(null);
            }
        }
        throw new ArgumentException("Not found.", "text");
        // or return default(T);
    }
	

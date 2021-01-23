    static TEnum GetEnum<TEnum>(object obj)
        where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("TEnum must be an enumerated type");                
        return (TEnum)(IConvertible)(Convert.ToInt32(obj));
    }

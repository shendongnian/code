    public void SetProperty<TRecord, TEnum>(TRecord item,
                                    Action<TRecord, TEnum> property, string enumValue)
        where TEnum : struct
        where TRecord : class
    {
        TEnum enumType;
        if (Enum.TryParse(enumValue, true, out enumType))
        {
            property(item, enumType);
        }
    }

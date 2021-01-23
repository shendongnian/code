    Type tEnum = types.Where(d => d.Name == "TEnum").FirstOrDefault();
    if (value.ToString() == "Test2")
    {
        object testEnum = Enum.Parse(tEnum.GetType(), value);
        var testEnumType = Convert.ChangeType(testEnum, tEnum.GetType());
    }

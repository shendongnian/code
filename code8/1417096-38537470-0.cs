    public static MyEnum GetEnum(int value)
    {
        var enumValue = (MyEnum)value;
        switch (enumValue)
        {
            case MyEnum.Apple:
            case MyEnum.Banana:
            case MyEnum.Orange:
               return enumValue;
            case MyEnum.Undefined:
            default:
               return MyEnum.Undefined;
        }

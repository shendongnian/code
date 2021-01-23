    public dynamic GetData()
    {
        dynamic data;
        switch (SomeType)
        {
            case SomeType.A:
                data = (Type_1)SomeType.Data;
            case SomeType.B:
                data = (Type_2)SomeType.Data;
            case SomeType.C:
                data = (Type_3) SomeType.Data;
            case SomeType.D:
                data = (Type_4) SomeType.Data;
            case SomeType.E:
                data = (Type_5) SomeType.Data;
            case SomeType.F:
                data = (Type_6) SomeType.Data;
            default: throw new NotSupportedException();
        }
        return data;
    }

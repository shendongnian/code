    MyEnum _myProperty;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public MyEnum MyProperty 
    { 
        get
        {
            return _myProperty;
        }
        set
        {
            if (Enum.IsDefined(typeof(MyEnum), value))
                _myProperty = value;
            else
                _myProperty = 0;
        }
    }

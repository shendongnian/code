    enum TestEnum
    {
        [Description("Start-up")]
        StartUp
    }
    TestEnum val = TestEnum.StartUp;
    string desc = GetEnumDescription((TestEnum)val);

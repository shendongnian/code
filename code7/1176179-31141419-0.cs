    public struct EnumsCombined
    {
         public EnumsCombined(TestEnum1 v) { Enum1 = v; }
         public EnumsCombined(TestEnum2 v) { Enum2 = v; }
         public TestEnum1? Enum1 { get; private set; }
         public TestEnum2? Enum2 { get; private set; }
    }

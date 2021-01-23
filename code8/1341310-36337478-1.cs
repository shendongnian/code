    public enum MyEnum
    {
    	[Description("Foo")]
    	A,
    	[Description("Bar")]
    	B,
    	[Description("Baz")]
    	C,
    }
    
    var list = EnumInfo.GetList<MyEnum>();

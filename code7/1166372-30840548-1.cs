    public enum MyEnum : long
    {
        Foo = 1
    }
    string str = Enum.Format(typeof(MyEnum), 1L, "G");

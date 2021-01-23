    public enum MyEnum
    {
        Foo = 1
    }
    string str = Enum.Format(typeof(MyEnum), 1, "G"); // Foo

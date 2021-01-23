    public enum Values
    {
        Foo = 10,
        Bar = 1
    }
    int ix = EnumOrder<Values>.IndexOf(Values.Bar); // 1

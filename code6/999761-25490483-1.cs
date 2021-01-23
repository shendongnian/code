    public enum Foo
    {
        [Description("Hello")]
        Bar,
        [Description("World")]
        Baz
    }
    var value = Foo.Bar;
    var description = value.GetDescription(); // Hello

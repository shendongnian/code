    public static class MyClass
    {
        public const int MyStaticProperty = 5;
    }
    [StringLength(MyClass.MyStaticProperty)]
    public string Code { get; set; }

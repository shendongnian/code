    public class MyClass
    {
        [Editor(typeof(MyClassEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(MyConverter))]
        public string MyProperty { get; set; }
    }

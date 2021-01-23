    public class TestEnumExtension : TypedValueExtension<TestEnum>
    {
        public TestEnumExtension(TestEnum value) : base(value) { }
    }
    
    public class TypedValueExtension<T> : MarkupExtension
    {
        public TypedValueExtension(T value) { Value = value; }
        public T Value { get; set; }
        public override object ProvideValue(IServiceProvider sp) { return Value; }
    }

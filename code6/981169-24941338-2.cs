    public abstract class BaseClass<T> where T : struct, IConvertible // almost only enums
    {
        public abstract T Specification { get; set; }
    }
    public class DerivedClass : BaseClass<EnumClass.MyEnum>
    {
        public EnumClass.MyEnum Specification { get; set; }
    }

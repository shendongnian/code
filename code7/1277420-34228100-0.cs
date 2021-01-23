    public class BaseClass<T> where T : BaseProperty
    {
        public T Property { get; set; }
    }
    public class DerivedClass : BaseClass<DerivedProperty>
    {
        public void MethodExample()
        {
            AClass aValue = Property.A;
        }
    }

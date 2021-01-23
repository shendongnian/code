    public abstract class BaseClass
    {
        public abstract System.Enum GetSpecification();
        public abstract void SetSpecification(System.Enum value);
    }
    public class DerivedClass : BaseClass
    {
        private EnumClass.MyEnum specification;
        public override EnumClass.MyEnum GetSpecification()
        {
            return specification;
        }
        public override void SetSpecification(EnumClass.MyEnum value)
        {
            specification = value;
        }
    }

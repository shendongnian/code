    public class BaseClass
    {
        public int baseNumber { get; set; }
        // So that BaseClass can't be created by other code through
        // the new BaseClass()
        protected BaseClass()
        {
        }
        public static BaseClass Create(bool derived)
        {
            BaseClass classInstance;
            if (derived)
            {
                classInstance = new DerivedClass();
            }
            else
            {
                classInstance = new BaseClass();
            }
            classInstance.baseNumber = 1234;
            if (derived)
            {
                ((DerivedClass)classInstance).derivedNumber = 4321;
            }
            return classInstance;
        }
    }
    public class DerivedClass : BaseClass
    {
        public int derivedNumber { get; set; }
        // So that BaseClass can't be created by other code through
        // the new BaseClass()
        protected DerivedClass()
        {
        }
    }

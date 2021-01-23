    public abstract class BaseClass
    {
        public int BaseNumber {get; set;}
    }
    
    public class DerivedClassA : BaseClass
    {
        public DerivedClassA()
        {
            BaseNumber = 1234;
        }
    }
    
    public class DerivedClassB : BaseClass
    {
        public DerivedClassB()
        {
            BaseNumber = 4321;
        }
    }

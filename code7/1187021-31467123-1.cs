    public class BaseClass
    {
        protected object RestrictedMember;
    }
    
    public DerivedClass : BaseClass
    {
        public DerivedClass() : base()
        {
            // You can access base class's protected member
            RestrictedMember = new object();
        }
    }

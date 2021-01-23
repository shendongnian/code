    public interface ICustomer
    {
        void DoSomethingCustomersDo();
    }
    
    public abstract class Customer : ICustomer
    {
        public string SomeSharedProperty { get; set; }
        public abstract void DoSomethingCustomersDo();
    }
    
    
    public class Person : Customer
    {
        public override void DoSomethingCustomersDo()
        {
            /* Person implementation */
        }
    }
    public class Organization : Customer
    {
        public override void DoSomethingCustomersDo()
        {
            /* Organization implementation */
        }
    }

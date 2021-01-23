    interface ICustomer
    {
        string Name     { get; set; }
        string Password { get; set; }
        string SomeOtherMethod();
    }
    public abstract class CustomerBase : ICustomer
    {
        public string Name     { get; set; }
        public string Password { get; set; }
        // We do not implement SomeOtherMethod() here.
        // Instead, make it abstract to force a non-abstract derived class to implement it:
        public abstract string SomeOtherMethod();
    }
    class Login: CustomerBase
    {
        // This class does not need to implement Name or Password,
        // because it can inherit them from CustomerBase.
        // However it must still implement SomeOtherMethod()
        // because that method is declared abstract in the base class.
        public override string SomeOtherMethod()
        {
            return "Implemented by me";
        }
    }

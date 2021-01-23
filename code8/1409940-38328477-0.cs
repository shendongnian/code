    public class Base
    {
        public virtual void SomeOtherMethod()
        {
          Console.WriteLine("Base some method");
        }
    }
    
    public class Derived : Base
    {
        public new void SomeOtherMethod()
        {
          Console.WriteLine("Derived some method");
        }
    }    
    
    Base b = new Derived();
    Derived d = new Derived();
    b.SomeOtherMethod();
    d.SomeOtherMethod();

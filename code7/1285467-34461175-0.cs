    public class BaseClass
    {
        public virtual void TestingSealed()
        {
            Console.WriteLine("This is testingSealed base");
        }
    }
    public class Derived : BaseClass
    {
        public override void TestingSealed()
        {
            base.TestingSealed(); // here
            Console.WriteLine("This is testing derived");
        }
        public void TestingSealedBase()
        {
            base.TestingSealed(); // or even here
        }
    }
    var der = new Derived();
    der.TestingSealed();
    der.TestingSealedBase();

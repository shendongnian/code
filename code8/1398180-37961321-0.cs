    public class A
    {
        public int MyProperty { get; set; }
    }
    public class B
    {
        public A GetAInstance()
        {
            A myInstance = new A();
            myInstance.MyProperty = 10;
            return myInstance;
        }
    }
    public class C
    {
        private B BInstance;
        public void InvokeA()
        {
            BInstance = new B();
            Console.WriteLine(BInstance.GetAInstance());
        }
    }

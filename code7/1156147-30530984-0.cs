    internal interface ITest
    {
         int MyProperty { get;}
         void ChangeValue();
    }
    class MyClass : ITest
    {
        public int MyProperty { get; private set; }
        public void ChangeValue()
        {
            MyProperty = 1;
        }
    }

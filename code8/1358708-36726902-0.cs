    public class MyClass
    {
        private readonly IUsedToBeBaseClass myDependency;
        public MyClass(IUsedToBeBaseClass myDependency){
            _myDependency = myDependency;
        }
        public void Method2()
        {
            _myDependency.Method1();
        }
    }

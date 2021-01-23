    public class MyClass 
    {
        private readonly string _myProp;
        private string MyProp => _myProp;
        private MyClass {_myProp = "Hello World"; }
    }

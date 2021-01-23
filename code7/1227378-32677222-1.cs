    public class MyDataProvider
    {
        private static readonly MyDataContainer _myDataContainer = new MyDataContainer();
        public MyDataContainer MyDataContainer { get { return _myDataContainer; } }
    }
    public class MyDataContainer
    {
        public MyClassType MyClass { get; private set; }
        ...
    }

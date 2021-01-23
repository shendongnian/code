    public class MyDataProvider
    {
        private static readonly MyDataContainer _myDataContainer = new MyDataContainer();
        public MyDataContainer MyDataContainer { get { return Strings; } }
    }
    public class MyDataContainer
    {
        public MyClassType MyClass { get; private set; }
        ...
    }

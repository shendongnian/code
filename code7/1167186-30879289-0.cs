    [TestFixture(typeof(Impl1MyInterface))]
    [TestFixture(typeof(Impl2MyInterface))]
    [TestFixture(typeof(Impl3MyInterface))]
    public class TesterOfIMyInterface<T> where T : IMyInterface {
    
        public IMyInterface _impl;
    
        [SetUp]
        public void CreateIMyInterfaceImpl() {
            int someInt1 = 5;
            string someString = "some value";
            _impl = (T)Activator.CreateInstance(typeof(T), new object[] { someInt1, someString });
        }
    }

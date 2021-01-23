    [TestClass]
    public class MyControllerTests
    {
        MyController _systemUnderTest;
        IMyInterface _myInterface;
        [TestInitialize]
        public void Setup()
        {
            _myInterface = new MyTestClass();
            _systemUnderTest = new MyController(_myInterface);
        }
    }

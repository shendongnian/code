    [TestClass]
    public class TMyClassTest
    {
        private Mock<ILocationProvider> _locationProvider = null;
    	private IEnumerable<ILocationProvider> _locationProviderCollection;
        private IMyInterface _myClass = null;
        [TestInitialize]
        public void InitializeTest ()
        {
            _locationProvider = new Mock<IEnumerable<ILocationProvider>>();
    		_locationProviderCollection = new List<ILocationProvider> { _locationProvider };
        }
        [TestMethod]
        public void ProvideRequireLocationObject_Test1()
        {
            //Given: I have type as 'PMI'
            string type = "PMI";
            //When: I call MyClass object
            _myClass = new MyClass(_locationProviderCollection); //wrong actual argument as the formal argument is an array of ILocationProvider
    		
    		.....
        }
    }

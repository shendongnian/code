    class Program
    {
        static void Main( string[] args )
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ITestServiceFactory, TestServiceFactory>();
            var theController = unityContainer.Resolve<TestController>();
            // theController._testService.FilterString is "abc"
        }
    }
    [MyFilter("abc")]
    public class TestController
    {
        private ITestService _testService;
        public TestController( ITestServiceFactory testServiceFactory )
        {
            _testService = testServiceFactory.CreateTestService(this);
        }
    }
    public class MyFilterAttribute : Attribute
    {
        public string FilterString
        {
            get;
        }
        public MyFilterAttribute( string filterString )
        {
            FilterString = filterString;
        }
    }
    public interface ITestServiceFactory
    {
        ITestService CreateTestService( object owner );
    }
    public interface ITestService
    {
        string GetText();
    }
    internal class TestServiceFactory : ITestServiceFactory
    {
        public ITestService CreateTestService( object owner )
        {
            return new TestService( ((MyFilterAttribute)owner.GetType().GetCustomAttribute( typeof( MyFilterAttribute ) )).FilterString );
        }
    }
    internal class TestService : ITestService
    {
        public TestService( string mystring )
        {
            _mystring = mystring;
        }
        public string GetText()
        {
            return _mystring;
        }
        private readonly string _mystring;
    }

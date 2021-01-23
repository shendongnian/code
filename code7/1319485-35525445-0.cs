    public interface IApplicationContext
    {
        string FooKey { get; set; }
    }
    public class ApplicationContext : IApplicationContext
    {
        public string FooKey
        {
            return HttpContext.Current.Application["fooKey"];
        }
    }
    
    public class YourTests
    {
        [TestInitialize]
        public void InitializeContext()
        {
            // From MOQ mocking framework. https://github.com/moq/moq4
            Mock<IApplicationContext> applicationMock = new Mock<IApplicationContext>();
            applicationMock.SetupGet(x => x.FooKey).Returns("foo");
        }
    }
    public class YourController : Controller
    {
        private IApplicationContext applicationContext;
        // Inject the application context using a dependency injection framework or manually in the constructor.
        public YourController (IApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            var foo = applicationContext.FooKey;
        }
    }

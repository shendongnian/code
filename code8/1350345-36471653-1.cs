    [TestFixture]
    public class ConfigurationControllerFixture : BaseServer
    {
        [Test]
        public async Task verify_should_get_data()
        {
            var response = await GetAsync(Uri);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        protected override string Uri
        {
            get { return "api/configuration"; }
        }
    }
    public abstract class BaseServer
    {
        protected TestServer Server;
        protected abstract string Uri { get; }
        protected virtual void OverrideConfiguration()
        {
            CompositionRoot.OverrideContainer = c =>
            {
                // new autofac configuration
                cb.Update(c);
            };
            AppStartup.OverrideConfiguration = c =>
            {
                // same as explained, but for HttpConfiguration
            };
        }
    }
    [SetUp]
    public void Setup()
    {
        OverrideConfiguration();
        Server = Microsoft.Owin.Testing.TestServer.Create(app =>
        {
           var startup = new AppStartup();
                startup.Configuration(app);
        });
        PostSetup(Server);
    }

    [SetUpFixture]
    public class AppHostSetupFixture
    {
        public static ServiceStackHost AppHost;
        [SetUp]
        public void Setup()
        {
            AppHost = new BasicAppHost(typeof(FeatureService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    var l = new List<string>();
                    l.Add(ConfigurationManager.ConnectionStrings["Redis"].ConnectionString);
                    container.Register<IRedisClientsManager>(c => new RedisManagerPool(l, new RedisPoolConfig() { MaxPoolSize = 40 }));
                }
            }
            .Init();
        }
        [TearDown]
        public void TearDown()
        {
            AppHost.Dispose();
        }
    }

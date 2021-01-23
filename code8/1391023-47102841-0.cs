    [TestClass]
    public class MatchRepositoryTests
    {
        private readonly IMatchRepository matchRepository;
        
        public MatchRepositoryTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMatchRepository, MatchRepository>();
            var serviceProvider = services.BuildServiceProvider();
            matchRepository = serviceProvider.GetService<IMatchRepository>();
        }
    }

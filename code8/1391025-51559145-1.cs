      [TestFixture]
        public class DependencyResolverTests
        {
            private DependencyResolverHelpercs _serviceProvider;
            public DependencyResolverTests()
            {
                var webHost = WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>()
                    .Build();
                _serviceProvider = new DependencyResolverHelpercs(webHost);
            }
    
            [Test]
            public void Service_Should_Get_Resolved()
            {
                
                //Act
                var YourService = _serviceProvider.GetService<IYourService>();
    
                //Assert
                Assert.IsNotNull(YourService);
            }
    
        }

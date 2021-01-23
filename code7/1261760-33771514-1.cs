    public class WebTestsFixture : IDisposable
    {
        private readonly IApplicationDeployer _deployer;
        private readonly IDisposable _loggerScope;
        public WebTestsFixture()
        {
            var logger = new LoggerFactory()
                .AddConsole(LogLevel.Information)
                .CreateLogger("Regression");
            _loggerScope = logger.BeginScope("RegressionTestSuite");
            var deploymentParameters = new DeploymentParameters(
                TestConfiguration.Configuration.Get<string>("Settings:ApplicationPath"),
                (ServerType)Enum.Parse(typeof(ServerType), TestConfiguration.Configuration.Get<string>("Settings:ServerType")),
                RuntimeFlavor.Clr,
                RuntimeArchitecture.x86)
            {
                ApplicationBaseUriHint = TestConfiguration.Configuration.Get<string>("Settings:ApplicationUri"),
                EnvironmentName = TestConfiguration.Configuration.Get<string>("Settings:EnvironmentName"),
                PublishWithNoSource = false
            };
            _deployer = ApplicationDeployerFactory.Create(deploymentParameters, logger);
            DeploymentResult = _deployer.Deploy();
        }
        public DeploymentResult DeploymentResult { get; private set; }
        public void Dispose()
        {
            _loggerScope.Dispose();
            _deployer.Dispose();
        }
    }

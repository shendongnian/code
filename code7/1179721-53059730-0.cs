    partial class IntegrationService : ServiceBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private System.Timers.Timer timer;
        public IntegrationService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                // Add code here to start your service.
                logger.Info($"Starting IntegrationService");
                var updateIntervalString = ConfigurationManager.AppSettings["UpdateInterval"];
                var updateInterval = 60000;
                Int32.TryParse(updateIntervalString, out updateInterval);
                var projectHost = ConfigurationManager.AppSettings["ProjectIntegrationServiceHost"];
                var projectIntegrationApiService = new ProjectIntegrationApiService(new Uri(projectHost));
                var projectDbContext = new ProjectDbContext();
                var projectIntegrationService = new ProjectIntegrationService(projectIntegrationApiService, projectDbContext);
                timer = new System.Timers.Timer();
                timer.AutoReset = true;
                var integrationProcessor = new IntegrationProcessor(updateInterval, projectIntegrationService, timer);
                timer.Start();
            }
            catch (Exception e)
            {
                logger.Fatal(e);
            }
        }
        protected override void OnStop()
        {
            try
            {
                // Add code here to perform any tear-down necessary to stop your service.
                timer.Enabled = false;
                timer.Dispose();
                timer = null;
            }
            catch (Exception e)
            {
                logger.Fatal(e);
            }
        }
    }

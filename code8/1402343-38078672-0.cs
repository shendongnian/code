        static void Main(string[] args)
        {
            //Get intial objects/settings
            ILogger logger = new Logger(Properties.Settings.Default.LoggingLevel, EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>());
            IDataProvider dataProvider = new SQLDataProvider();
            DMSPollingJobType availableJobTypes = DMSPollingJobType.FlatFile;
            if (Properties.Settings.Default.SupportsVPN)
            {
                availableJobTypes |= DMSPollingJobType.VPN;
            }
            String executableLocation = Properties.Settings.Default.ExecutableLocation;
            String jsLocation = Properties.Settings.Default.JSLocation;
            Int32 maxProcesses = Properties.Settings.Default.MaxProcesses;
            //Create job manager and start new processes/jobs
            DMSJobManager jobManager = new DMSJobManager(logger, dataProvider, availableJobTypes, executableLocation, jsLocation, maxProcesses);
            jobManager.StartNewJobs();
            // start message loop
            Application.Run();
        }

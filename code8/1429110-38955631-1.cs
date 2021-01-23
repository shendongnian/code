    [SetUpFixture]
    public class Config
    {
        public Config()
        {
        }
        public string baseDirectory;
        public static string screenshotDirectory;
        [OneTimeSetUp]
        public void SetUp()
        {
            Console.WriteLine("Creating a folder to capture failed scenarios");
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\" + ConfigurationManager.AppSettings.GetValues("failedTests")[0];
            string Browser = ConfigurationManager.AppSettings["WebDriver"];
            screenshotDirectory = baseDirectory + @"\" + (DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + "_" + Browser);
            Directory.CreateDirectory(screenshotDirectory);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
        }
    }

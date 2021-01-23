    public class Trial
    {
        static IWebDriver Instance = null;
        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Instance.Navigate().GoToUrl("www.google.com");
        }
        public static void Close()
        {
            Instance.Close();
        }
    }

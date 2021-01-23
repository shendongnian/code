        using OpenQA.Selenium.Firefox;
        public static class FirefoxInitialise
        {
          private static IWebDriver Driver{get; set;}
          public static IWebDriver Init()
          {
           // I'm assuming your geckodriver.exe is located there:
           // @"C:\MyGeckoDriverExePath\geckodriver.exe"
           FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\MyGeckoDriverExePath\");
           service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; // May not be necessary
           FirefoxOptions options = new FirefoxOptions();
           TimeSpan time = TimeSpan.FromSeconds(10);
           Driver = new FirefoxDriver(service, options, time);
           return Driver;
         }
        }
 So you can use :
    IWebDriver driver = FirefoxInitialise.Init();

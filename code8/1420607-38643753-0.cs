    desiredCapabilities = DesiredCapabilities.Chrome();
    var options = new ChromeOptions();
    options.AddArgument(@"--incognito");
    options.AddArgument("--start-maximized");
    desiredCapabilities.SetCapability(ChromeOptions.Capability, options);
    webDriver = new MyWebDriver(new Uri(gridHubURL), options.ToCapabilities(),TimeSpan.FromSeconds(ApplicationConfiguration.RemoteDriverTimeOutValue),testContext);
                       
    webDriver.Manage().Window.Maximize();
     break; 

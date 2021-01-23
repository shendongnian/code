    var options = new InternetExplorerOptions();
    options.EnsureCleanSession = true;
    DesiredCapabilities cap = (DesiredCapabilities)options.ToCapabilities();
    cap.SetCapability(CapabilityType.BrowserName, DesiredCapabilities.InternetExplorer());
    // continue adding other capabilities
    IWebDriver driver = new RemoteWebDriver(cap)

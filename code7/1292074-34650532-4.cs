    Dictionary<string, IWebDriver> driversByHandles;
    IWebDriver driver1;
    IWebDriver driver2;
    IWebDriver driver3; 
    [SetUp]
    public void SetUp()
    {
        driversByHandles = new Dictionary<string, IWebDriver>();
        driver1.Navigate().GoToUrl(Url);
        driversByHandles.Add(driver1.CurrentWindowHandle, driver1);
        driver2.Navigate().GoToUrl(Url);
        driversByHandles.Add(driver2.CurrentWindowHandle, driver2);
        ...
    }
    [Test]
    public void Test()
    {
        foreach(KeyValuePair<string, IWebDriver> entry in driversByHandles)
        {
            if (entry.Key.equals(targetHandle))
            {
                entry.Value.SwitchTo().Window(entry.Key);
            }
        }
    }

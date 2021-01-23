    public static void Click(this IWebElement element, TestTarget target)
    {
        if (target.IsFirefox)
        {
            var actions = new Actions(target.Driver);
            actions.MoveToElement(element);
    
            // special workaround for the FirefoxDriver
            // otherwise sometimes Exception: "Cannot press more then one button or an already pressed button"
            target.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
            // temporarily disable implicit wait
            actions.Release().Build().Perform();
            target.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(MyDefaultTimeoutInSeconds));
    
            Thread.Sleep(500);
            actions.MoveToElement(element);
            actions.Click().Build().Perform();
        }
        else
        {
            element.Click();
        }
    }

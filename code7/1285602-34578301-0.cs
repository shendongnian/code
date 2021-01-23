    [BeforeScenario]
    public void RunBeforeScenario()
    {
        objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);
        // HERE INSTEAD
        seleniumContext.driver.Navigate().GoToUrl("http://localhost:8080");
    }

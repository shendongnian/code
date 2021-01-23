    [BeforeScenario()]
    public void BeforeScenario()
    {
        if(ScenarioContext.Current.ScenarioInfo.Tags.Contains("Tag01")
          && ScenarioContext.Current.ScenarioInfo.Tags.Contains("Tag02"))
        {
             StepBase.CreateBrowser(ConfigurationManager.AppSettings["BrowserType"]);
             Console.WriteLine("selenium open Called");
        }
    }
    

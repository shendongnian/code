    public class Hooks
    {
        private bool BeforeScenarioDoneAlready{get;set;}
        [BeforeScenario("Tag01", "Tag02")]
        public void BeforeScenario()
        {
            if (!DoneBeforeScenarioAlready)
            {
                 StepBase.CreateBrowser(ConfigurationManager.AppSettings["BrowserType"]);
                 Console.WriteLine("selenium open Called");
                 BeforeScenarioDoneAlready=true;
            }
        }
    }

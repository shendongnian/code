    public class SpecialTest : YourNormalFeatureClass
    {
        private Xunit.Abstractions.ITestOutputHelper helper;
        public SpecialTest(ITestOutputHelper helper) : base()
        {
            this.helper = helper;   
        }
        public override void ScenarioSetup(ScenarioInfo scenarioInfo)
        {
            base.ScenarioSetup(scenarioInfo);
            // you'd want a better way to keep track of this string
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().ScenarioContext.Set(this.helper, "helper");
        }
    }

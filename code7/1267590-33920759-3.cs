    [Xunit.FactAttribute()]
    [Xunit.TraitAttribute("FeatureTitle", "Score Calculation (alternative forms)")]
    [Xunit.TraitAttribute("Description", "One single spare")]
    public virtual void OneSingleSpare()
    {
        TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("One single spare", ((string[])(null)));
    #line 7
        this.ScenarioSetup(scenarioInfo);
    #line 8
        testRunner.Given("a new bowling game");
    #line 9
        testRunner.When("I roll the following series:\t3,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1");
    #line 10
        testRunner.Then("my total score should be 29");
    #line hidden
        testRunner.CollectScenarioErrors();
    }

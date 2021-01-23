    [Given("Something nice")]
    public void WhenIStartSomething()
    {
        // Add an inspector  to the current context
        var currentPageInspector = ScenarioContext.Current.Set("PageInspector", new PageInspector());
    
    
        // Construct other stuff
        ScenarioContext.Current.Add("signInInstance", SignIn(...));
    }
    
    
    [When("I do something planned")]
    public void WhenIDoSomethingPlanned()
    {
        var signIn = ScenarioContext.Current.Get<SignIn>();
    
        // do the action with signIn
    }
    
    [Then("I should see the following result")]
    public void ThenIShouldSeeTheFollowingResult()
    {
        var currentPageInspector = ScenarioContext.Current.Get<PageInspector>();
    
        currentPageInspector.CurrentPage.Title.ShouldEqual("My Landing Page");
    }

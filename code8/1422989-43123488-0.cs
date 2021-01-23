    [BeforeScenario]
    public void BeforeScenario()
    {
        ScenarioContext.Current.Set(false, "HasNotImplementedStep");
    }
    [BeforeStep]
    public void BeforeStep()
    {
        ScenarioContext.Current.Set(true, "IsBeforeStepCalled");
    }
    [AfterStep]
    public void AfterStep()
    {
        var beforeStepCalled = ScenarioContext.Current.Get<bool>("IsBeforeStepCalled");
        if (!beforeStepCalled)
        {
            ScenarioContext.Current.Set(true, "HasNotImplementedStep");
        }
        ScenarioContext.Current.Set(false, "IsBeforeStepCalled");
    }
    [AfterScenario]
    public void AfterScenario()
    {
        var hasNotImplementedStep = ScenarioContext.Current.Get<bool>("HasNotImplementedStep");
        if (hasNotImplementedStep)
        {
            // Do your stuff
        }
    }

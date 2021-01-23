    [TearDown]
    public void TearDown()
    {
    	var state = TestContext.CurrentContext.Result.State;
    	if (state == TestState.Error || state == TestState.Failure)
    	{
    		Utilities.Core.TakeScreenshot(this._chromeDriver, TestContext.CurrentContext.Test.FullName);
    	}
    
    	_driver.Quit();
    }

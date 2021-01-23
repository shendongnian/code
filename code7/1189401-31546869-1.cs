    private boolean IsElementVisible(By by)
    {
        try
        {
            return driver.FindElement(by).IsDisplayed();
        }
        catch(NoSuchElementException e)
        {
            return false;
        }
    }
    private List<By> VerifyElementVisibility(
              List<By> expectedVisibile, List<By> expectedInvisible)
    {
        List<By> failedExpectations = new List<By>();
         
        for (By by in expectedVisible)
        {
            if(!IsElementVisible(by)
            {
                failedExpectations.Add(by);
            }
        }
        for (By by in expectedInvisible)
        {
            if(IsElementVisible(by)
            {
                failedExpectations.Add(by);
            }
        }
        return failedExpectations;
    }
    List<By> failedExpectations = VerifyElementVisiblity(visibleElements, invisibleElements);
    Assert.IsTrue(failedExpectations.Count == 0);

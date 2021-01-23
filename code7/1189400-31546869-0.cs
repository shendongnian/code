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
    
    Assert.IsTrue(IsElementVisible(by1));
    Assert.IsFalse(IsElementVisible(by2));

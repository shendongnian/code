    public static void WaitForElementPresentBy(By by)
            {
                try
                {
                    Wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                catch (TimeoutException te)
                {
    
                    Assert.Fail("The element with selector {0} didn't appear. The exception was:\n {1}", by, te.ToString());
                }
            }

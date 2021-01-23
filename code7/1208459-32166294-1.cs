    Assert.AreEqual(true, IsElementPresent(By.Id("s_m_HeaderContent_MainTitle"),driver));
    public bool IsElementPresent(By by, IWebDriver driver)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

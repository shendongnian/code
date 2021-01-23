    public void ClickByCssSelectorIeSafe(string cssSelector)
    {
        IWebElement element = null;
        try
        {
            element = _driver.FindElement(By.CssSelector(cssSelector));
            element.Click();
        }
        catch (NoSuchElementException e)
        {
            Console.WriteLine("element not found. {0}", e.Message);
            //do something here when your element is not found
        }
        catch (WebDriverException e)
        {
            if (element != null) element.SendKeys("\n");
        }
    }

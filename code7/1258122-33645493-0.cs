    IWebElement searchInput = Driver.FindElement(By.Id("lst-ib"));
    searchInput.SendKeys(command);
    searchInput.SendKeys(Keys.Enter);
    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
    By linkLocator = By.CssSelector("cite._Rm");
    wait.Until(ExpectedConditions.ElementToBeClickable(linkLocator));
    IReadOnlyCollection<IWebElement> links = Driver.FindElements(linkLocator);
    foreach (IWebElement link in links)
    {
        Console.WriteLine(link.Text);
    }

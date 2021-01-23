    IReadOnlyCollection<IWebElement> types = Driver.FindElements(By.CssSelector("div.types"));
    foreach (IWebElement type in types)
    {
        Assert.Istrue(type.FindElement(By.CssSelector("div.span7")).FindElements(By.TagName("b")).Count > 0);
    }

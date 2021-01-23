    IList<IWebElement> element = driver.FindElements(By.Name("category"));
    foreach (IWebElement e in element)
    {
            var parentLabel = e.FindElement(By.XPath(".."));
            if (parentLabel.Text.Contains(my text))
            {
                parentLabel.Click();
                break;
            }
    }
    

    IWebElement element = driver.FindElement(By.Id("btnBuildAllSubmit"));
    string disabledAttributeValue = element.GetAttribute("disabled");
    if(disabledAttributeValue == null)
    {
        // The disabled attribute is not present
    }

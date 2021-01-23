    public static IWebElement WaitAndFindElement(By by, int timeoutInSeconds)
    {
        WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        IWebElement elem = webDriverWait.Until<IWebElement>((d) =>
                {
                  IWebElement element =  d.FindElement(by);
                  if (element.Displayed &&
        element.Enabled)
                  {
                    return element;
                  }
                  return null;
                });
       return elem;
     }

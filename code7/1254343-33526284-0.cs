    public static IList<IWebElement> GetSelectListByID(string elementID)
    {
        IWebElement mySelectElm = WebDriver.FindElement(By.Id(elementID));
        SelectElement mySelect = new SelectElement(mySelectElm);
        return mySelect.Options;
    }

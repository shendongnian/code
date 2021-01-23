    public static bool Validation()
    {
        IList<IWebElement> messages = Driver.Instance.FindElements(By.XPath("html/body/section[2]/div/div/div/div/form/div[1]/div[2]/span/span"));
        foreach (IWebElement message in messages)
        {
            if (!message.Displayed)
            {
                return false; // one of the messages isn't displayed
            }
        }
        
        return true; // all the messages are displayed
    }
        

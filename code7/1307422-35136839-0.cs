    public static void setAttribute(this IWebElement element, string value, bool clearFirst)
    {
        if (clearFirst) element.Clear();
        element.SendKeys(value);
    }
   

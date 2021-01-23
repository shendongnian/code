    public static void SendKeys(this IWebElement element, TestTarget target, string text)
    {
        if (target.IsEdge)
        {
            int index = text.LastIndexOfAny(new[] { '@', 'Ł', 'ó', 'ź' }) + 1;
            if (index > 0)
            {
                ((IJavaScriptExecutor) target.Driver).ExecuteScript(
                    "arguments[0].value='" + text.Substring(0, index) + "';", element);
                text = index == text.Length ? Keys.Space : text.Substring(index);
            }
        }
    
        element.SendKeys(text);
    }

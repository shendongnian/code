    public static IWebElement FindParent(this IWebElement e, int parentLevel = 1)
    {
        return (e == null || parentLevel <= 0)
                ? e
                : e.FindElement(By.XPath("..")).FindParent(--parentLevel);
    }

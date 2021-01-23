    [Then(@"I select the following list item '(.*)' from my search")]
    public static void PreSelectedListOptions(string value)
    {
        var suggestedList = Driver.Instance.FindElements(By.CssSelector(".list-reset li"));
        foreach (IWebElement suggestion in suggestedList)
        {
            if (value.Equals(suggestion.Text))
            {
                suggestion.Click();
                break;
            }
        }
    }

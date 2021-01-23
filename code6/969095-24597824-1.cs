    public static AutomationElement GetSpecificWindow(string aWinTitle)
    {
        AutomationElement mainWindow = null;
        AutomationElementCollection winCollection = AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
    
        foreach (AutomationElement ele in winCollection)
        {
            if (ele.Current.Name.ToLower() == aWinTitle.ToLower())
            {
                mainWindow = ele;
                break;
            }
        }
        return mainWindow;
    }
    public static AutomationElement GetSpecificAutomationItem(string aWinTitle, string itemName)
    {
        AutomationElement window = GetSpecificWindow(aWinTitle);      
        Condition condition = new PropertyCondition(AutomationElement.NameProperty, itemName);
        return window.FindFirst(TreeScope.Element | TreeScope.Descendants, condition);
    }

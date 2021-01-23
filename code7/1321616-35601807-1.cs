    SortedDictionary<double, AutomationElement> orderedTabItems = new SortedDictionary<double, AutomationElement>();
    
    // Loop through all tabs
    var tabItemCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
    foreach (AutomationElement tabItem in elemTabStrip.FindAll(TreeScope.Children, tabItemCondition))
    {
        Rect rectangleProperty = (Rect)tabItem.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
        orderedTabItems.Add(rectangleProperty.X, tabItem);
    }
                
    for(int i = 0; i < orderedTabItems.Keys.Count; i++)
    {
        var key = orderedTabItems.Keys.ElementAt(i);
        var tabItem = orderedTabItems[key];
        var nameProperty = tabItem.GetCurrentPropertyValue(AutomationElement.NameProperty);
        Debug.WriteLine("index: " + i + ", title: " + nameProperty.ToString());
    }

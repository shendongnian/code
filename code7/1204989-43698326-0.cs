    public IEnumerable<ITab> GetTabsOfWindow(IntPtr hWnd)
    {
      var cacheRequest = new CacheRequest();
      cacheRequest.Add(AutomationElement.NameProperty);
      cacheRequest.Add(AutomationElement.LocalizedControlTypeProperty);
      cacheRequest.Add(SelectionItemPattern.Pattern);
      cacheRequest.Add(SelectionItemPattern.SelectionContainerProperty);
      cacheRequest.TreeScope = TreeScope.Element;
      AutomationElement tabBarElement;
      using (cacheRequest.Activate())
      {
        var chromeWindow = AutomationElement.FromHandle(hWnd);
        var mainElement = chromeWindow.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
        if (mainElement == null)
          yield break;
        tabBarElement = mainElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "tab"));
      }
      if(tabBarElement == null)
        yield break;
      var tabElements = tabBarElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "tab item"));
      for (var tabIndex = 0; tabIndex < tabElements.Count; tabIndex++)
      {
        yield return "Tab: " + tabElements[tabIndex].Current.Name + ", Index: " + tabIndex + 1;
      }
    }

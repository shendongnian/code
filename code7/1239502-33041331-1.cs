    public void CacheElement(IUIAutomationElement element)
    {
        var automation = new CUIAutomation();
        var request = automation.CreateCacheRequest();
        request.AutomationElementMode = AutomationElementMode.AutomationElementMode_None;
        request.AddProperty(30005); // 30005 is nameProperty
        var results = element.FindAllBuildCache(
                TreeScope.TreeScope_Descendants,
                automation.CreatePropertyCondition(30003, 50020), // 30003 is control type property 50020 is TEXT control type
                request
            );
    }

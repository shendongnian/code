    IUIAutomation uiAutomation = new CUIAutomation();
    IUIAutomationElement rootElement = uiAutomation.GetRootElement();
    int propertyIdName = 30005; // UIA_NamePropertyId
    // First find the Run dlg, which is a direct child of the root element.
    // For this test, assume there's only one element whose title is "Run"
    // beneath the root. Note! This only works in English UI.
    IUIAutomationCondition conditionName =
        uiAutomation.CreatePropertyCondition(
            propertyIdName, "Run");
    IUIAutomationElement wndElement = rootElement.FindFirst(
        TreeScope.TreeScope_Children, conditionName);
    if (wndElement != null)
    {
        // Ok, we have the Run dialog. Now find the Browse button through its AutomationId.
        int propertyAutomationId = 30011; // UIA_AutomationIdPropertyId
        // Using the Inspect SDK tool, I could see that the AutomationId of
        // the Browse button is "12288".
        IUIAutomationCondition conditionAutomationId =
            uiAutomation.CreatePropertyCondition(
                propertyAutomationId, "12288");
        // Get the name of the button cached when we find the button, so that 
        // we don't have to make a cross-process call later to get the name.
        IUIAutomationCacheRequest cacheRequestName = uiAutomation.CreateCacheRequest();
        cacheRequestName.AddProperty(propertyIdName);
        IUIAutomationElement btnElement = wndElement.FindFirstBuildCache(
            TreeScope.TreeScope_Children, conditionAutomationId, cacheRequestName);
        if (btnElement != null)
        {
            // Let's see the name now...
            MessageBox.Show(btnElement.CachedName);
        }
    }

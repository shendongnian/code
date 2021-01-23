    IUIAutomation uiAutomation = new CUIAutomation8();
    IUIAutomationElement rootElement = uiAutomation.GetRootElement();
    // Assume the first child of the root element with a ClassName of 
    // "OpusApp" is the Word window we're interested in.
    int propertyIdClassName = 30012; // UIA_ClassNamePropertyId
    IUIAutomationCondition conditionWordApp =
        uiAutomation.CreatePropertyCondition(
            propertyIdClassName, "OpusApp");
    IUIAutomationElement wordElement =
        rootElement.FindFirst(
            TreeScope.TreeScope_Children,
            conditionWordApp);
    // Find the File Tab beneath the Word element. Use the AutomationId 
    // to find the button rather than the Name, because AutomationId will 
    // not be localized.
    int propertyAutomationId = 30011; // UIA_AutomationIdPropertyId
    IUIAutomationCondition conditionFileTab =
        uiAutomation.CreatePropertyCondition(
            propertyAutomationId,
            "FileTabButton");
    // Cache the Invoke pattern when we get the FileTab element, so 
    // that we don't have to make another cross-process call later to 
    // get the pattern.
    int patternIdInvoke = 10000; // UIA_InvokePatternId
    IUIAutomationCacheRequest cacheRequestInvokePattern = 
        uiAutomation.CreateCacheRequest();
    cacheRequestInvokePattern.AddPattern(patternIdInvoke);
    IUIAutomationElement fileTabElement =
        wordElement.FindFirstBuildCache(
            TreeScope.TreeScope_Descendants,
            conditionFileTab,
            cacheRequestInvokePattern);
    // Now invoke the tab.
    IUIAutomationInvokePattern invokePatternFileTab = 
        fileTabElement.GetCachedPattern(patternIdInvoke);
    invokePatternFileTab.Invoke();
    // Note that sometimes when making calls like this, it may be necessary to 
    // Thread.Sleep() for a short time here, to give the target app a chance to 
    // create and show the UI being invoked.
    // Find the Info item. Unfortunately the item has no AutomationId, 
    // so use other properties to find it. For this test, just use the 
    // localizable Name and ControlType. (So this means this code won't 
    // work for non-English builds of Word.)
    int propertyIdName = 30005; // UIA_NamePropertyId
    IUIAutomationCondition conditionInfoItemName =
        uiAutomation.CreatePropertyCondition(
            propertyIdName, "Info");
    IUIAutomationCondition conditionInfoItemClassName =
        uiAutomation.CreatePropertyCondition(
            propertyIdClassName, "NetUIRibbonTab");
    IUIAutomationCondition conditionInfoItem = uiAutomation.CreateAndCondition(
        conditionInfoItemName, conditionInfoItemClassName);
    int patternIdSelectionItem = 10010; // UIA_SelectionItemPatternId
    IUIAutomationCacheRequest cacheRequestSelectionItemPattern = 
        uiAutomation.CreateCacheRequest();
    cacheRequestSelectionItemPattern.AddPattern(patternIdSelectionItem);
    IUIAutomationElement infoItemElement =
        wordElement.FindFirstBuildCache(
            TreeScope.TreeScope_Descendants,
            conditionInfoItem,
            cacheRequestSelectionItemPattern);
    // Now select the Info item, to show the "Check for issues" UI.
    IUIAutomationSelectionItemPattern selectionItemPatternInfoItem = 
        infoItemElement.GetCachedPattern(patternIdSelectionItem);
    selectionItemPatternInfoItem.Select();
    // Now find the "Check for issues" element. This element also has no
    // AutomationId, so just search for the Name and ClassName again.
    IUIAutomationCondition conditionInfoCheckForIssuesName =
        uiAutomation.CreatePropertyCondition(
            propertyIdName, "Check for Issues");
    IUIAutomationCondition conditionCheckForIssuesClassName =
        uiAutomation.CreatePropertyCondition(
            propertyIdClassName, "NetUIAnchor");
    IUIAutomationCondition conditionCheckForIssues = 
        uiAutomation.CreateAndCondition(
            conditionInfoCheckForIssuesName, conditionCheckForIssuesClassName);
    int patternIdExpandCollapse = 10005; // UIA_ExpandCollapsePatternId
    // Expand the "Check for issues" UI, to show the "Check Accessibility" 
    // button.
    IUIAutomationCacheRequest cacheRequestExpandCollapsePattern = 
        uiAutomation.CreateCacheRequest();
    cacheRequestExpandCollapsePattern.AddPattern(patternIdExpandCollapse);
    IUIAutomationElement checkForIssuesElement =
        wordElement.FindFirstBuildCache(
            TreeScope.TreeScope_Descendants,
            conditionCheckForIssues,
            cacheRequestExpandCollapsePattern);
    IUIAutomationExpandCollapsePattern expandCollapsePatternCheckForIssues = 
        checkForIssuesElement.GetCachedPattern(patternIdExpandCollapse);
    expandCollapsePatternCheckForIssues.Expand();
    // Finally find the "Check Accessibility" element. This element also has no
    // AutomationId, so once again, just search for the Name and ClassName.
    IUIAutomationCondition conditionInfoCheckAccessibilityName =
        uiAutomation.CreatePropertyCondition(
            propertyIdName, "Check Accessibility");
    IUIAutomationCondition conditionCheckAccessibiltyClassName =
        uiAutomation.CreatePropertyCondition(
            propertyIdClassName, "NetUITWBtnMenuItem");
    IUIAutomationCondition conditionCheckAccessibility = 
        uiAutomation.CreateAndCondition(
            conditionInfoCheckAccessibilityName, 
            conditionCheckAccessibiltyClassName);
    IUIAutomationElement checkAccessibilityElement =
        wordElement.FindFirstBuildCache(
            TreeScope.TreeScope_Descendants,
            conditionCheckAccessibility,
            cacheRequestInvokePattern);
    // Invoke this element to check the document's accessibility.
    IUIAutomationInvokePattern invokePatternCheckAccessibility =
        checkAccessibilityElement.GetCachedPattern(patternIdInvoke);
    invokePatternCheckAccessibility.Invoke();
    

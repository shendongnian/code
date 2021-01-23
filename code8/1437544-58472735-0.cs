    Process[] allChromeProcesses = Process.GetProcessesByName("chrome");
    Process[] mainChromes = allChromeProcesses.Where(p => !String.IsNullOrEmpty(p.MainWindowTitle)).ToArray();
    //...
    //Here you need to check if you have found correct chrome instance
    //...
    var uiaClassObject = new CUIAutomation();
    IUIAutomationElement chromeMainUIAElement = uiaClassObject.ElementFromHandle(mainChromes[0].MainWindowHandle);
    //UIA_ControlTypePropertyId =30003, UIA_TabItemControlTypeId = 50019
    IUIAutomationCondition chromeTabCondition = uiaClassObject.CreatePropertyCondition(30003, 50019); 
    var chromeTabCollection = chromeMainUIAElement.FindAll(TreeScope.TreeScope_Descendants, chromeTabCondition);
    //UIA_LegacyIAccessiblePatternId = 10018, 0 -> Number of Chrome tab you want to activate
    var lp = chromeTabCollection.GetElement(0).GetCurrentPattern(10018) as IUIAutomationLegacyIAccessiblePattern;
    lp.DoDefaultAction();

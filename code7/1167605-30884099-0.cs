    public static void EnableSmoothMotion()
    {
        bool finished = false;
        // wait for the settings window to show
        Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Children, (sender, e) =>
        {
            var window = (AutomationElement)sender;
            if (window.Current.ClassName != "TFMadVRSettings")
                return;
    
            // get the tree element
            var tree = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tree));
    
            // get the smooth motion element & select it
            var smoothMotion = tree.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "smooth motion"));
            ((SelectionItemPattern)smoothMotion.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
    
            // get the tab element
            var tab = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab));
    
            // get the pane element
            var pane = tab.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));
    
            // get the first checkbox & ensure it's clicked
            var cb = pane.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));
            TogglePattern tp = (TogglePattern)cb.GetCurrentPattern(TogglePattern.Pattern);
            if (tp.Current.ToggleState != ToggleState.On) // not on? click it
            {
                ((InvokePattern)cb.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
            }
    
            // NOTE: uncomment the two following line if you want to close the window directly
            // get the ok button & push it
            //var ok = window.FindFirst(TreeScope.Children, new AndCondition(
            //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
            //    new PropertyCondition(AutomationElement.NameProperty, "OK")));
            //((InvokePattern)ok.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
    
            finished = true;
        });
    
        // run the program
        Process p = new Process();
        p.StartInfo.FileName = @"C:\Users\Admin\Desktop\madVR\madHcCtrl.exe";
        p.StartInfo.Arguments = "editLocalSettingsDontWait";
        p.Start();
    
        while(!finished)
        {
            Thread.Sleep(100);
        }
        Automation.RemoveAllEventHandlers();
    }

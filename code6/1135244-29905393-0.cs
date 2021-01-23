    Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Children, new AutomationEventHandler(NewWindowHandler));
    public void NewWindowHandler(Object sender, AutomationEventArgs e)
    {
        AutomationElement element = (AutomationElement)sender;
        if (element.Current.Name == "PUT YOUR NAME HERE") 
        {
            HwndSource hSource = HwndSource.FromHwnd(new IntPtr(element.Current.NativeWindowHandle));
            MyWindow = hSource.RootVisual as WavefrontToolkit.FormulaEditor.FormulaEditor;
            Assert.IsNotNull(_MyWindow );
            }
        }
    }

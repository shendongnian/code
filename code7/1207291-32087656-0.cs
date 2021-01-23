    AutomationElement windowElement = AutomationElement.FromHandle(WindowHandle);
    if(windowElement != null)
    {
                System.Windows.Automation.Automation.AddAutomationPropertyChangedEventHandler(
                        windowElement,
                        System.Windows.Automation.TreeScope.Element, this.handlePropertyChange,
                        System.Windows.Automation.AutomationElement.BoundingRectangleProperty);
    }
		private void handlePropertyChange(object src, System.Windows.Automation.AutomationPropertyChangedEventArgs e)
		{
            if(e.Property == System.Windows.Automation.AutomationElement.BoundingRectangleProperty)
            {
                System.Windows.Rect rectangle = e.NewValue as System.Windows.Rect; 
                //Do other stuff here
            }
        }

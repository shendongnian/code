        AutomationEventHandler UIAEventHandler = new AutomationEventHandler(OnUIAEvent);
        Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent,
                        AutomationElement.RootElement,
                        TreeScope.Descendants, UIAEventHandler);
        private static void OnUIAEvent(object src, AutomationEventArgs e)
        {
            AutomationElement element = src as AutomationElement;
            
			if (element == null)
			{
				return;
			}
            AutomationElement openButton = element.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "4426"));
            if (openButton != null)
            {
                openButton.SetFocus();
                
                ((InvokePattern)openButton.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
            }
        }

		private void AddEmailSendEvent()
		{
			// Find the new email window
			PropertyCondition newEmailWindowCondition = new PropertyCondition(AutomationElement.NameProperty, "Untitled - Message (HTML) ");
			AutomationElement NewEmailWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, newEmailWindowCondition);
			// Find the Send Button
			PropertyCondition sendEmailButtonCondition = new PropertyCondition(AutomationElement.NameProperty, "Send");
			AutomationElement sendButton = NewEmailWindow.FindFirst(TreeScope.Descendants, sendEmailButtonCondition);
			// If supported, add the invoke event
			if (sendButton.GetSupportedPatterns().Any(p => p.Equals(InvokePattern.Pattern)))
				Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, sendButton, TreeScope.Element, handler);
		}
		private void handler(object sender, AutomationEventArgs e)
		{   
			// Do whatever is needed, for testing this just adds a message to my forms Main UI
			AddMessage("Invoke event occured");
		}

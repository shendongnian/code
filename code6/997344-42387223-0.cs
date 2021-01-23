    using System.Windows.Automation;
    
    Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent,
                mainWindow.AutomationElement,
                TreeScope.Descendants,
                (sender, e) =>
                {
                    var element = sender as AutomationElement;
                    if (!(element.Current.LocalizedControlType == "Dialog" && element.Current.Name == "modalWindowTitle"))
                        return;
                    Automation.RemoveAllEventHandlers();
                    // Here run your code. The modal window was opened
                });

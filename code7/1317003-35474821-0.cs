    `AutomationFocusChangedEventHandler focusHandler = null;
    
    /// <summary>
    /// Create an event handler and register it.
    /// </summary>
    public void SubscribeToFocusChange()
    {
        focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
        Automation.AddAutomationFocusChangedEventHandler(focusHandler);
    }
    
    /// <summary>
    /// Handle the event.
    /// </summary>
    /// <param name="src">Object that raised the event.</param>
    /// <param name="e">Event arguments.</param>
    private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
    {
        // TODO Add event handling code.
        // The arguments tell you which elements have lost and received focus.
        System.Windows.Automation.AutomationElement element = src as System.Windows.Automation.AutomationElement;
        if(element.Current.ProcessId == "MontioredApplicationProcessId")
        {
            //Monitored application has focus!
        }
        else
            //Monitored application does not have focus
    }
    
    /// <summary>
    /// Cancel subscription to the event.
    /// </summary>
    public void UnsubscribeFocusChange()
    {
        if (focusHandler != null)
        {
            Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
        }
    }`

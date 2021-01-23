    public void HandleAutomationEvent(IUIAutomationElement sender, int eventId)
    {
        // Got a window opened event...
        // Get the RuntimeId from the source element. Because that data is cached with the
        // event, we don't have to call back through UIA into the provider process here.
        int[] runtimeId = sender.GetCachedPropertyValue(propertyRuntimeId);
    }

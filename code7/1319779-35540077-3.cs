    protected override void Configure()
    {
        base.Configure();
    
        Parser.CreateTrigger = delegate(DependencyObject target, string triggerText)
        {
            System.Windows.Interactivity.EventTrigger eventTrigger;
            if (triggerText == null)
            {
                ElementConvention elementConvention = ConventionManager.GetElementConvention(target.GetType());
                return elementConvention.CreateTrigger();
            }
            string eventName = triggerText.Replace("[", String.Empty).Replace("]", String.Empty);
            if (eventName.StartsWith("Delayed", StringComparison.OrdinalIgnoreCase))
            {
                eventName = eventName.Replace("DelayedEvent", String.Empty).Trim();
                eventTrigger = new DelayedEventTrigger();
            }
            else
            {
                eventName = eventName.Replace("Event", String.Empty).Trim();
                eventTrigger = new System.Windows.Interactivity.EventTrigger();
            }
    
            eventTrigger.EventName = eventName;
            return eventTrigger;
        };     
    }

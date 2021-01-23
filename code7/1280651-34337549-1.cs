    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        private RoutedEventTrigger CreateRoutedEventTrigger(DependencyObject target, string routedEvent)
        {
            var routedEvents = EventManager.GetRoutedEvents().ToDictionary(r => $"{r.OwnerType.Name}.{r.Name}");
            if (routedEvents.ContainsKey(routedEvent))
            {
                var trigger = new RoutedEventTrigger
                {
                    RoutedEvent = routedEvents[routedEvent]
                };
                trigger.Attach(target);
                return trigger;
            }
            return null;
        }
        protected override void OnStartup(object sender, StartupEventArgs args)
        {
            var baseCreateTrigger = Parser.CreateTrigger;
            Parser.CreateTrigger = (target, triggerText) =>
            {
                var baseTrigger = baseCreateTrigger(target, triggerText);
                var baseEventTrigger = baseTrigger as EventTrigger;
                return CreateRoutedEventTrigger(target, baseEventTrigger?.EventName ?? "") ?? baseTrigger;
            };
           ...
        }
        ...
    }

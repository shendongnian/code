    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        public RoutedEvent RoutedEvent { get; set; }
        protected override void OnAttached()
        {
            var element = (AssociatedObject as Behavior as IAttachedObject)?.AssociatedObject as UIElement
                      ?? AssociatedObject as UIElement;
            element?.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
        }
        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            OnEvent(args);
        }
        protected override string GetEventName()
        {
            return RoutedEvent.Name;
        }
    }

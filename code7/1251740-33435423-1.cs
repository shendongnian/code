    public class AttachedEventTrigger : EventTriggerBase<DependencyObject>
    {
        public RoutedEvent RoutedEvent { get; set; }
    
        private FrameworkElement AssociatedElement
        {
            get
            {
                IAttachedObject attachedObject = AssociatedObject as IAttachedObject;
                FrameworkElement associatedElement = AssociatedObject as FrameworkElement;
    
                if (attachedObject != null)
                {
                    associatedElement = attachedObject.AssociatedObject as FrameworkElement;
                }
    
                return associatedElement;
            }
        }
    
        protected override void OnAttached()
        {
            FrameworkElement associatedElement = AssociatedElement;
    
            if (associatedElement == null)
            {
                throw new InvalidOperationException();
            }
    
            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
            }
        }
    
        protected override void OnDetaching()
        {
            FrameworkElement associatedElement = AssociatedElement;
    
            if (RoutedEvent != null)
            {
                associatedElement.RemoveHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
            }
        }
    
        private void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            OnEvent(args);
        }
    
        protected override string GetEventName()
        {
            if (RoutedEvent != null)
            {
                return RoutedEvent.Name;
            }
    
            return String.Empty;
        }
    }

    public class State : UIElement
    {
    
        public State()
        {
    
        }
    
        private bool _status;
        public bool Status
        {
            get { return (bool)GetValue(StatusProperty); }
            set
            {
                SetValue(StatusProperty, value);
    
                if (value != _status)
                {
                    _status = value;
    
                    if (value)
                    {
                        this.StatusText = "Activated";
                    }
                    else
                    {
                        this.StatusText = "Deactivated";
                    }
    
    
                    RaiseStatusChangedEvent();
                }
    
    
            }
        }
    
        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(bool), typeof(State), new PropertyMetadata(InternStatusChanged));
    
    
        static void InternStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Nullable<bool> value = e.NewValue as Nullable<bool>;
            if (value.HasValue)
            {
                ((State)d).Status = value.Value;
    
            }
    
      
        }
    
    
    
        public string StatusText
        {
            get { return (string)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for StatusText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register("StatusText", typeof(string), typeof(State), new PropertyMetadata(""));
    
    
    
        // Create a custom routed event by first registering a RoutedEventID 
        // This event uses the bubbling routing strategy 
        public static readonly RoutedEvent StatusChangedEvent = EventManager.RegisterRoutedEvent(
            "StatusChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(State));
    
        // Provide CLR accessors for the event 
        public event RoutedEventHandler StatusChanged
        {
            add { AddHandler(StatusChangedEvent, value); }
            remove { RemoveHandler(StatusChangedEvent, value); }
        }
    
        // This method raises the SelectedPathChanged event 
        void RaiseStatusChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(State.StatusChangedEvent);
            RaiseEvent(newEventArgs);
        }
    
    
        
    
    
    
    }
    

     private void NotifyListeners()
        {
            RoutedEventArgs args = new RoutedEventArgs(RegisteredListeners);
            RaiseEvent(args);
        }
        /// <summary>
        /// The RoutedEvent registered Listeners using a tunneling strategy
        // </summary>
        public static readonly RoutedEvent RegisteredListeners =
         EventManager.RegisterRoutedEvent("RoutedEventListener", RoutingStrategy.Tunnel,
         typeof(RoutedEventHandler), typeof(Router));
        /// <summary>
        /// Event Handler registration
        /// </summary>
        public event RoutedEventHandler OnNewMessageReceived
        {
            add { AddHandler(RegisteredListeners, value); }
            remove { RemoveHandler(RegisteredListeners, value); }
        }
      /// <summary>
      /// Called when a command is set and all Registered Listeners are notified
      /// </summary>
      public static EventHandler<EventArgs> OnNotifyNewMessage;

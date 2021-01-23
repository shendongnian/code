        public static class WindowNotifier2
        {
            public static event CreatedDelegateCallback IamCreatedEvent;
            public delegate void CreatedDelegateCallback(object sender, WindowNotifierEventArgs args);
    
            public static event ClosingDelegateCallback IamClosingEvent;
            public delegate void ClosingDelegateCallback(object sender, WindowNotifierEventArgs args);
    
            public static event ClosedDelegateCallback IamClosedEvent;
            public delegate void ClosedDelegateCallback(object sender, WindowNotifierEventArgs args);
    
    
            public static void OnIamCreated(object sender, WindowNotifierEventArgs args)
            {
                if (IamCreatedEvent != null)
                    IamCreatedEvent(sender, args);
            }
    
            public static void OnIamClosing(object sender, WindowNotifierEventArgs args)
            {
                if (IamClosingEvent != null)
                    IamClosingEvent(sender, args);
            }
    
            public static void OnIamClosed(object sender, WindowNotifierEventArgs args)
            {
                if (IamClosedEvent != null)
                    IamClosedEvent(sender, args);
            }
    
        }
    
        public class WindowNotifierEventArgs : EventArgs
        {
            public IntPtr WindowHandle { get; set; }
        }

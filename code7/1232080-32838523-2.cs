    public static class WindowNotifier
        {
            public static event CreatedDelegateCallback IamCreatedEvent;
            public delegate void CreatedDelegateCallback(IntPtr handle);
    
            public static event ClosingDelegateCallback IamClosingEvent;
            public delegate void ClosingDelegateCallback (IntPtr handle);
    
            public static event ClosedDelegateCallback IamClosedEvent;
            public delegate void ClosedDelegateCallback(IntPtr handle);
    
            public static void OnIamCreated(IntPtr handle)
            {
                if (IamCreatedEvent != null)
                    IamCreatedEvent(handle);
            }        
    
            public static void OnIamClosing(IntPtr handle)
            {
                if (IamClosingEvent != null)
                    IamClosingEvent(handle);
            }
    
            public static void OnIamClosed(IntPtr handle)
            {
                if (IamClosedEvent != null)
                    IamClosedEvent(handle);
            }
        }

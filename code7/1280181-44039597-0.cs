     public static class ControlTreeExtensions
        {
            public static TContainer ClosestContainer<TContainer>(this Control theControl) where TContainer : Control
            {
                if (theControl == null) throw new ArgumentNullException("theControl");
    
                Control current = theControl.NamingContainer;
                TContainer result = current as TContainer;
                while (current != null && result == null)
                {
                    current = current.NamingContainer;
                    result = current as TContainer;
                }
    
                return result;
            }
        }

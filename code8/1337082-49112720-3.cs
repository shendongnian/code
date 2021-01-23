    public static void RemoveEventHandlers(this MulticastDelegate m){
    
            string eventName=nameof(m);
    
            EventInfo eventInfo=m.GetType().ReflectingType.GetEvent(eventName,BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
    
    
            Delegate[] subscribers = m.GetInvocationList();
    
            Delegate currentDelegate;
    
            for (int i = 0; i < subscribers.Length; i++) {
    
                currentDelegate=subscribers[i];
                eventInfo.RemoveEventHandler(currentDelegate.Target,currentDelegate);
    
            }
    
        }

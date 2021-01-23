    class MyDelegateHelperClass{
        public static void RemoveEventHandlers<TModel, TItem>(MulticastDelegate m, Expression<Func<TModel, TItem>> expr) {
        
        
                    EventInfo eventInfo= ((MemberExpression)expr.Body).Member as EventInfo;
        
        
                    Delegate[] subscribers = m.GetInvocationList();
        
                    Delegate currentDelegate;
        
                    for (int i = 0; i < subscribers.Length; i++) {
        
                        currentDelegate=subscribers[i];
                        eventInfo.RemoveEventHandler(currentDelegate.Target,currentDelegate);
        
                    }
                }
    }

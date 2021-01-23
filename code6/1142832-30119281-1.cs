    Public class EventExposer
    {
      private Dictionary<Type, IList> subscriber;
    
      public EventExposer()
      {
                subscriber = new Dictionary<Type, IList>();
      }
      
       public void AddEvent(Action action)
       {
                Type t = typeof(action.Target);
                if (!subscriber.ContainsKey(t))
                {
                        subscriber.Add(t, action);
                }
       }
    
    }

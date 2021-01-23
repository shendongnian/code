    public void Subscribe(object listener)
    {
       if(listener is IEventListener)
       {
           AddSubscriber(interfaceType.GetGenericTypeDefinition(), listener);
       }
    }

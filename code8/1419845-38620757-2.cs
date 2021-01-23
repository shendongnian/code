    public void RegisterListener<T>(Action<T> listener) where T : class 
    {
        Action<object> wrappingAction = (arg)=>
        {
           var castArg = arg as T;
           if(castArg != null)
           {
               listener(castArg);
           }
        };
 
        Listeners.Add(wrappingAction);    
    }
 

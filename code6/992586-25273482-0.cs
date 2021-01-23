    public static void DoOnUIThread(some parameters)
    {
      // You can use parameters now.  Obviously "some" is not a type, but you would replace this with the type you're using for your parameters.
    }
    
    public static void AddEventTypeToList(some parameters)
    {
        // Change Action<Type> to use the type of the parameter you want
           Deployment.Current.Dispatcher.BeginInvoke(new Action<some>(DoOnUIThread));
    }   

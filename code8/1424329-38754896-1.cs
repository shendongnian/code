    EventInfo evClick = tExForm.GetEvent("Click");
    Type tDelegate = evClick.EventHandlerType;
    // If you already have a method with the correct signature,
    // you can simply get a MethodInfo for it. 
    //
    MethodInfo miHandler = 
        typeof(Example).GetMethod("LuckyHandler", 
            BindingFlags.NonPublic | BindingFlags.Instance);
    // Create an instance of the delegate. Using the overloads
    // of CreateDelegate that take MethodInfo is recommended.
    Delegate d = Delegate.CreateDelegate(tDelegate, this, miHandler);
    // Get the "add" accessor of the event and invoke it late-
    // bound, passing in the delegate instance. This is equivalent
    // to using the += operator in C#, or AddHandler in Visual
    // Basic. The instance on which the "add" accessor is invoked
    // is the form; the arguments must be passed as an array.
    //
    MethodInfo addHandler = evClick.GetAddMethod();
    Object[] addHandlerArgs = { d };
    addHandler.Invoke(exFormAsObj, addHandlerArgs);

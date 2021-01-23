    class EventTesterClass // Simple class that raise an event
    {
        public event EventHandler Func;
    
        public void RaiseEvent()
        {
            Func(null, EventArgs.Empty);
        }
    }
    
    static void subscribeEventBeforeOthers<InstanceType>(InstanceType instance, string eventName, EventHandler handler) // Magic method that unsubscribe subscribed methods, subscribe the new method and resubscribe previous methods
    {
        Type instanceType = typeof(InstanceType);
        var eventInfo = instanceType.GetEvent(eventName);
        var eventFieldInfo = instanceType.GetField(eventInfo.Name,
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance |
                                            BindingFlags.GetField);
    
        var eventFieldValue = (System.Delegate)eventFieldInfo.GetValue(instance);
        var methods = eventFieldValue.GetInvocationList();
    
        foreach (var item in methods)
        {
            eventInfo.RemoveEventHandler(instance, item);
        }
        eventInfo.AddEventHandler(instance, handler);
        foreach (var item in methods)
        {
            eventInfo.AddEventHandler(instance, item);
        }
    }
    
    static void Main(string[] args)
    {
        var evntTest = new EventTesterClass();
        evntTest.Func += handler_Func;
        evntTest.Func += handler_Func1;
        evntTest.RaiseEvent();
        Console.WriteLine();
        subscribeEventBeforeOthers(evntTest, "Func", handler_Func2);
        evntTest.RaiseEvent();
    }
    
    static void handler_Func(object sender, EventArgs e)
    {
        Console.WriteLine("handler_Func");
    }
    
    static void handler_Func1(object sender, EventArgs e)
    {
        Console.WriteLine("handler_Func1");
    }
    
    static void handler_Func2(object sender, EventArgs e)
    {
        Console.WriteLine("handler_Func2");
    }

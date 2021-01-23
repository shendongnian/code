    private static object GetDelegate(Control issuer, string keyName)
    {
        // Get key value for a Click Event
        var key = typeof(Control)
            .GetField(keyName, BindingFlags.Static | BindingFlags.NonPublic | 
                                   BindingFlags.FlattenHierarchy)
            .GetValue(null);
        var events = typeof(Component)
            .GetField("events", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(issuer);
        // Find the Find method and use it to search up listEntry for corresponding key
        var listEntry = typeof(EventHandlerList)
            .GetMethod("Find", BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(events, new object[] { key });
        // Get handler value from listEntry 
        var handler = listEntry
            .GetType()
            .GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(listEntry);
        return handler;
    }

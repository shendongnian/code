    string GetSubscriptions(object o)
    {
        Type t = o.GetType();
        // Obtain the collection of EventInfo's
        var events = t.GetEvents();
        if (events.Length == 0)
        {
            return "No events in " + t.Name;
        }
        string result = string.Empty;
        foreach (var item in events)
        {
            result += "Event " + item.Name + ": ";
            // Get the event's backing field description (FieldInfo)
            var ed = t.GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic);
            if (ed == null)
            {
                throw new InvalidOperationException("Event backing field could not be obtained");
            }
            // Get the value of the backing field
            var dl = ed.GetValue(o) as Delegate;
            // If value is not null, then we've subscriptions
            if (dl != null)
            {
                // Get the invocation list - an array of Delegate
                var il = dl.GetInvocationList();
                // This check is actually not needed, since the array shoudl always contain at least 1 item
                if (il.Length != 0)
                {
                    // Use Target property of the delegate to get a reference to the object the delegate's method belongs to
                    result += string.Join("; ", il.Select(i => i.Target.GetType().Name + "." + i.Method.Name)) + Environment.NewLine;
                    continue;
                }
            }
            result += "no subscriptions" + Environment.NewLine;
        }
        return result;
    }

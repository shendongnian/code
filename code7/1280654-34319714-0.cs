    if (invocation.Method.IsEventAttach())
    {
        var delegateInstance = (Delegate)invocation.Arguments[0];
        // TODO: validate we can get the event?
        var eventInfo = this.GetEventFromName(invocation.Method.Name.Substring(4));
        if (ctx.Mock.CallBase && !eventInfo.DeclaringType.IsInterface)
        {
            invocation.InvokeBase();
        }
        else if (delegateInstance != null)
        {
            ctx.AddEventHandler(eventInfo, (Delegate)invocation.Arguments[0]);
        }
        return InterceptionAction.Stop;
    }

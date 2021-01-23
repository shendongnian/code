    public void HookUp(Control container, string handlerName, string eventName)
    {
        MethodInfo eventHandler = this.GetType().GetMethod(handlerName, BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var control in container.Controls.Cast<Control>())
        {
            var ev = control.GetType().GetEvent(eventName);
            if (ev == null)
                continue;
            var d = Delegate.CreateDelegate(ev.EventHandlerType, this, eventHandler);
            ev.AddEventHandler(control, d);
        }
    }

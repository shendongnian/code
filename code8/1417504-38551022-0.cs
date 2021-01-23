    // Notify GUI that the blocking plugin was activated.
    OnBlockingPluginActive(this, EventArgs.Empty);
    
    string result;
    Func<int> processAsync = () => blockingPlugin.Process(input, out result);
    processAsync.BeginInvoke(ar =>
    {
        var status = processAsync.EndInvoke(ar);
        if (status == 0)
        {
            // OK, notify GUI and fire a BlockingPluginOK command in finite state machine.
            OnBlockingPluginOK(this, EventArgs.Empty);
        }
        else
        {
           // Error, notify GUI and fire a BlockingPluginError command in finite state machine.
           OnBlockingPluginError(this, EventArgs.Empty);
        }
    }, null);

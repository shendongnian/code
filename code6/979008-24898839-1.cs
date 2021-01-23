    public virtual Task OnDisconnected(bool stopCalled)
    {
        if (stopCalled)
        {
            // We know that Stop() was called on the client,
            // and the connection shut down gracefully.
        }
        else
        {
            // This server hasn't heard from the client in the last ~35 seconds.
            // If SignalR is behind a load balancer with scaleout configured, 
            // the client may still be connected to another SignalR server.
        }
    
        return base.OnDisconnected(stopCalled);
    }

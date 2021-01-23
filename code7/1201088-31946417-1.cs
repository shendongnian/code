    public override void Post(SendOrPostCallback callback, object state)
    {
        if (controlToSendTo != null)
        {
            controlToSendTo.BeginInvoke(callback, new object[] { state });
        }
    }

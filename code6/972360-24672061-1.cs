    public void Control_Event(object sender, EventArgs e)
    {
        var uiContext = SynchronizationContext.Current;
        Task.Run(() => 
        {
            // do some work
            uiContext.Post(/* update UI controls*/);
        }
    }

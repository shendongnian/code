    protected virtual void OnArriveHome(BreadWinnerEventArgs args)
    {
        var handler = ArrivedHome;
    
        if (handler == null)
            return;
    
        foreach (var subscriber in handler.GetInvocationList())
        {
            try
            {
                subscriber(this, args);
            }
            catch (Exception ex)
            {
                //You can, and probably should, remove the handler from the list here
            }
        }
    }

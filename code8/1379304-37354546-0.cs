    public static event EventHandler TickerLoopIterated;
    
    private void InvokeTickerLoopEvent()
    {
        if (null != TickerLoopIterated)
        { TickerLoopIterated(this, EventArgs.Empty); }
    }

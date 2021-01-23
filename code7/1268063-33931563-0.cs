    private EventHandler _click;
    public event EventHandler Click
    {
        add { _click += value; }
        remove { _click -= value; }
    }
    // Or even shorter...
    // public event EventHandler Click;
    // ... which is the same as above plus extra stuff for thread safety.

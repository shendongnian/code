    public IEnumerable<B> GetBs()
    {
        return containerList.OfType<B>();
    }
    
    public IEnumerable<C> GetCs()
    {
        return containerList.OfType<C>();
    }

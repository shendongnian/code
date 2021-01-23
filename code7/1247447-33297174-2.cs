    public void ReadStuff(IReadOnlyIndexable<T, K> instance) 
    {
        // read from instance
    }
    public void ReadOrWrite(IIndexable<T, K> instance)
    {
        // write to instance
        ReadStuff(instance); // and you can simply pass it as IReadOnlyIndexable
    }

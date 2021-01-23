    public T GetFirst()
    {
        lock(Synchro)
        {
            return firstNode.Item;
        }
    }

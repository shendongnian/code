    public void Dispose()
    {
        if (!isCommitted)
        {
            // Was an exception thrown before this is called?
            // If not, I might consider throwing one here.
            // I can't always throw an exception here because if
            // another exception is already propagated, it would
            // be dropped and the real error cause would not be
            // visible anymore.
        }
    }

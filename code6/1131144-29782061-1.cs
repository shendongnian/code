    public bool IsCancellationRequested 
    {
        get
        {
            return m_source != null && m_source.IsCancellationRequested;
        }
    }

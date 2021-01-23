    /// <summary>
    /// Move viewstate to session
    /// </summary>
    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new SessionPageStatePersister(Page);
        }
    }

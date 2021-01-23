    protected override void PostDeserialize()
    {
        base.PostDeserialize();
        
        if (A == null && (B == null || C == null))
        {
            throw new ConfigurationErrorsException("...");
        }
    }

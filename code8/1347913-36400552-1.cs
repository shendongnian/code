    public Guid GetSessionGuid(int key)
    {
        try
        {
            return UserSessionLookupTable[key].SessionGuid
        }
        catch
        {
            return null;
        }
    }

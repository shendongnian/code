    public Guid GetSessionGuid(int key)
    {
        UserSession session; 
        return UserSessionLookupTable.TryGetValue(key, out session) ? session.SessionGuid : null;
    }

    public static void RemoveUserAndSessions(string userId, string objectId)
    { 
        ActiveUsers.Remove(userId);
        Parallel.ForEach(ActiveUsers.Values, dic => dic.Remove(objectId));
    }

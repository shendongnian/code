    public void AddMatchmakingUser(MatchmakingUser user)
    {
        lock (matchmakingUsers)
        {
            matchmakingUsers.Add(user);
        }
    }

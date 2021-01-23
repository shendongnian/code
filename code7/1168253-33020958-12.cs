    public User GetGetUserWithLowestLoad(ILocateUsers users, ILocateTickets tickets)
    {
    	User lowest = null;
        foreach(var id in userIds)
        {
            var user = users.GetById(id);
            if(user.IsLoadedLowerThan(lowest, tickets))
            {
                lowest = user;
            }
        }
        return lowest;
    }

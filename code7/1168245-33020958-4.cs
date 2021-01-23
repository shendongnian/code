    public User GetGetUserWithLowestLoad(Repository repository)
    {  
        User lowest = null;
        
        foreach(var id in userIds)
        {        
            var user = repository.Get<User>(id);
            if(user.IsLoadedLowerThan(lowest))
            {           
                lowest = user;
            }
        }
        return lowest;
    }

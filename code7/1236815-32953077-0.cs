    public List<User> GetUsers(int pageNumber = 0) //pageNumber is the page you are on
    {
        int itemsPerPage = 30;
        var orderedUsers = dbContext.User.OrderByDescending(u => u.Age)
                          .Skip(itemsPerPage * pageNumber)
                          .Take(itemsPerPage).ToList();
        return orderedUsers;
    }

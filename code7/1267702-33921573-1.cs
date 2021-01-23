    public List<UserDto> GetUsers()
    {
        return myDbContext.Users
                    .Select(x=> new UserDto { Id = x.Id, Name =x.Name }).ToList();
    }

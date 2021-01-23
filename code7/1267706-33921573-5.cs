    var users = dbContext.Users.Select(s => new UserDto
    {
        Id = s.Id,
        Name = s.Name,
        UserType = new UserTypeDto
        {
            Id = s.UserType.Id,
            Name = s.UserType.Name
        }
    });

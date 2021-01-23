    var query =
        from user in context.Users
        select new ProjectUsersDTO
        {
            UserName = user.Name,
            Rate = user.RatePerHour,
            UserId = user.UserId,
            alreadyInProject = user.Projects.Any(userProj => userProj.ProjectId == projectId)
        };
    var result = query.ToList();

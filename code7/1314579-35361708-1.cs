    from user in context.Users
    join userProj in context.UserProjects.Where(up => up.ProjectId == projectId)
        on user.UserId equals userProj.UserId into g
    from subuserProject in g.DefaultIfEmpty()
    select new ProjectUsersDTO {
        UserName = user.Name,
        Rate = user.RatePerHour,
        UserId = user.UserId,
        alreadyInProject = (subuserProject != null)
    }

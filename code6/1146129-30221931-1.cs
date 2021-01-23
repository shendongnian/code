    var projectsToDelete = new List<Project>();
    foreach (var relationship in user.Users2Projects)
    {
        if (relationship.Project.Users2Projects.Count() <= 1)
            projectsToDelete.Add(relationship.Project);
    }
    Context.MyCustomUsers.Remove(user);
    Context.Projects.RemoveRange(projectsToDelete);
    Context.SaveChanges();

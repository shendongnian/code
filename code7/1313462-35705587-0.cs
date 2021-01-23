    AddRule(new DelegateValidator<Command>((aCommand, aContext) =>
    {
        // return an IEnumerable<ValidationFailure> from in here:
        var projectId = (int?) aCommand.ProjectId;
        if (projectId.HasValue)
        {
    
            using (var dbContextScope = aDbContextScopeFactory.CreateReadOnly())
            {
                MyDbContext dbContext = dbContextScope.DbContexts.Get<MyDbContext>();
                Project project = dbContext.Projects.Find(projectId);
                if (project == null)
                {
                    return Enumerable.Repeat(new ValidationFailure("ProjectId", "ProjectId not found"),1);
                }
    
                var projectValidator = new ProjectValidator();
                var results = projectValidator.Validate(project);
    
                return results.Errors;
            }
        }
        return null;
    }));

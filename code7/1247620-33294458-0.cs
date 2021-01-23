    var availableTasks = dbContext.Projects
        .Where(p => p.ProjectId == projectId)
        .SelectMany(p => dbContext.Tasks
            .Where( t => p.TasksMode == ProjectTasksMode.AllowAll || (t.ProjectId == projectId))
            .Select( t => new TaskOption { TaskId = tId, Name = t.Name}))
        .ToList();

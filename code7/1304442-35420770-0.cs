    var projectTaskIndex = await _mongoContext.Projects
        .Find(p => p.ProjectID == projectID)
        .Project(p => p.ProjectTasks.FindIndex(t => t.ProjectTaskID == projectTaskID))
        .SingleOrDefaultAsync();
    var updateDefinition = new UpdateDefinitionBuilder<Project>()
        .AddToSet(p => p.ProjectTasks[projectTaskIndex].Comments, comment);
    
    await _mongoContext.Projects
        .UpdateOneAsync(p=> p.ProjectID == projectID, updateDefinition);

    public IEnumerable<Resource> GetResourcesForViewsByProjectId(Guid ProjectId)
    {
        var resources = Uow.Tasks.Join(
                Uow.Assignments,
                task => task.GUID,
                    assignment => assignment.TaskId,
                    (task, assignment) => new
                    {
                        Task = task,
                        Assignment = assignment
                    })
                .Join(Uow.Resources,
                    j => j.Assignment.ResourceId,
                    resource => resource.GUID,
                    (j, resource) => new
                    {
                        Task = j.Task,
                        Assignment = j.Assignment,
                        Resource = resource
                    })
                .Where(j => j.Task.ProjectId == ProjectId)
                .Select(j => j.Resource);
        return resources;
    }

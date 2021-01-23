    ExecuteTasks = ReactiveCommand.CreateAsyncTask(canExecute, async _ =>
    {
        object result = null;
        foreach (var item in Tasks)
        {
            item.Clear();
            item.Validate();
        }
        if (Tasks.Any(e => e.Status == TaskStatus.Error))
        {
            Tasks.Reset();
            return result;
        }
        foreach (var item in Tasks)
        {
            item.Status = XrmTools.Plugins.TaskStatus.Running;
            await ExecuteAsync(item);
            item.Status = XrmTools.Plugins.TaskStatus.Completed;
        }
        return result;
    });
    Task ExecuteAsync(IPlugin item)
    {
        return Task.Run(() => item.Execute());
    }

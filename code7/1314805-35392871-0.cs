    public async Task<HttpResponseMessage> RunTask(TaskType taskType)
    {
        var taskId = await TaskManager.CreateTask(taskType);
        await TaskManager.Run(taskId);
    
        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content =
                new StringContent($"Task {taskType.GetDescription()} was started.")
        };
    }

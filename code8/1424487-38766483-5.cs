    string target = "A";
    int taskCounter = 0;
    int taskCount = 0;
    Setup(context => {
                // declare recursive task count function
                Func<string, List<string>, int> countTask = null;
                countTask = (taskName, countedTasks) => {
                        if (string.IsNullOrEmpty(taskName) || countedTasks.Contains(taskName))
                        {
                            return 0;
                        }
                        countedTasks.Add(taskName);
                        var task = Tasks.Where(t=>t.Name == taskName).FirstOrDefault();
                        if (task == null)
                        {
                            return 0;
                        }
                        int result = 1;
                        countedTasks.Add(taskName);
                        foreach(var dependecy in task.Dependencies)
                        {
                            result+=countTask(dependecy, countedTasks);
                        }
                        return result;
                };
            // count the task and store in globally available variable
            taskCount = countTask(target, new List<string>());
        });
    TaskSetup(
        taskSetupContext => {
            ICakeTaskInfo task = taskSetupContext.Task;
            Information("Executing Task {0} of {1} (Name: {2}, Description: {3}, Dependencies: {4})",
                ++taskCounter,
                taskCount,
                task.Name,
                task.Description,
                string.Join(",",
                        task.Dependencies
                        )
                );
        });
    Task("A")
        .Description("Alpha")
        .IsDependentOn("B")
        .Does(()=>{});
    Task("B")
        .Description("Beta")
        .IsDependentOn("C")
        .Does(()=>{});
    Task("C")
        .Description("Charlie")
        .IsDependentOn("D")
        .Does(()=>{});
    Task("D")
        .Description("Delta")
        .Does(()=>{});
    Task("E")
        .Description("Echo")
        .Does(()=>{});
    Task("F")
        .Description("Foxtrot")
        .Does(()=>{});
    RunTarget(target);

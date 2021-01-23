    private async Task StartSeveralTasks()
    {
        var taskA = OperationA(),
        var taskB = OperationB(),
        var taskC = OperationC(...),
        };
        await Task.WhenAll(new Task[] {taskA, taskB, taskC});
        // because taskB is a Task<string>, taskB has a property Result:
        string book = taskB.Result;
    }
 

    var tasks = new Task[]
                {
                    task1,
                    task2
                };
    await Task.WhenAll(tasks);
    var task1Result = ((Task<Task1Result>)tasks[0]).Result;
    var task2Result = ((Task<Task2Result>)tasks[1]).Result;

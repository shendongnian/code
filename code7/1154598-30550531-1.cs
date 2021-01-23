    [Theory, AutoMoqData]
    public void TestSomething(Task task)
    {
        task.TaskState = TaskState.InProgress;
        task.Progress = 50;
        // The rest of the test...
    }

    [Theory, AutoMoqData]
    public void TestSomething(Task task)
    {
        task.TaskState = TaskState.InProgress;
        // The rest of the test...
    }

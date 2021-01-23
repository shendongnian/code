    [Test]
    public async Task AwaitWithTimeout_Calls_ErrorDelegate_On_NeverEndingTask()
    {
        var taskToAwait = new TaskCompletionSource<object>().Task;
        var successCalled = false;
        await TaskHelper.AwaitWithTimeout(taskToAwait, 10, () => successCalled = true, null);
        Assert.IsTrue(successCalled);
    }

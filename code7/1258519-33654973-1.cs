    class FakeTask : IWorkTask
    {
      private readonly TaskCompletionSource<object> _done = new TaskCompletionSource<object>();
      public Task Done { get { return _done.Task; } }
      public Task DoWork()
      {
        ++TimesRun;
        if (TimesRun > 1)
          _done.TrySetResult(null);
        return Task.CompletedTask;
      }
    }
    [Fact]
    public async Task Start_GivenTask_RerunsTaskUntilStopped()
    {
      var agent = CreateKlarnaAgent();
      var fakeTask = DoNothingTask();
      agent.Start(fakeTask);
      await fakeTask.Done;
      await agent.Stop();
      Assert.True(fakeTask.TimesRun > 1); // spurious test at this point
    }

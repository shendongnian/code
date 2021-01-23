    [Test]
    public async Task MyTestMethod()
    {
      await WindowsFormsContext.Run(async () =>
      {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(10);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
      });
    }

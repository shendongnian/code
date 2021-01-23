    [Test]
    public void MyTestMethod()
    {
      AsyncContext.Run(async () =>
      {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(10);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
      });
    }

    [TestMethod]
    public void Run()
    {
        Func<Task<string>> work = GetSampleResultAsync;
        Action<InvalidOperationException> onException = e => Console.WriteLine("Caught the exception: {0}", e);
        TimeSpan retryInterval = TimeSpan.FromSeconds(5);
        int maxRetryCount = 4;
        Task<string> resultTask = Retry(work, onException, retryInterval, maxRetryCount);
        Console.WriteLine("This wrapper doesn't block");
        var result = resultTask.Result;
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        Assert.AreEqual("Sample result!", result);
    }
    private static int _counter;
    private static Task<string> GetSampleResultAsync()
    {
        if (_counter < 3)
        {
            _counter++;
            throw new InvalidOperationException("Baaah!");
        }
        return CompletedTask.FromResult("Sample result!");
    }

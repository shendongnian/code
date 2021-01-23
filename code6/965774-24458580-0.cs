    [Fact]
    public async Task MyTest()
    {
        var x = new Subject<bool>();
        var firstBool = x.FirstAsync().PublishLast(); // PublishLast wraps an AsyncSubject
        firstBool.Connect();
        // Send the first bool
        x.OnNext(true);
        // Await the task that receives the first bool
        var b = await firstBool;
        Assert.Equal(true, b);
    }

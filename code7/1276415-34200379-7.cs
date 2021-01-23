    using Xunit;
    [Fact]
    public async Task DefaultIfFaultedTest()
    {
        var success = Task.Run(() => 42);
        var faulted = Task.Run(new Func<int>(() => { throw new InvalidOperationException(); }));
        Assert.Equal(42, await success.DefaultIfFaulted());
        Assert.Equal(0, await faulted.DefaultIfFaulted());
        await Assert.ThrowsAsync<TaskCanceledException>(() =>
        {
            var tcs = new TaskCompletionSource<int>();
            tcs.SetCanceled();
            return tcs.Task.DefaultIfFaulted();
        });
    }

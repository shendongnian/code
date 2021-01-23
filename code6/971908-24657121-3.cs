    [Test]
    public async Task MyTest()
    {
        var source = // ...;
        var source2 = source.RetryWithBackoffStrategy(/*...*/);
        var result = await source2; // you can await observables
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public async Task MyTest()
    {
        var source = // ...;
        var result = await source; // you can await observables
        Assert.That(result, Is.EqualTo(5));
    }

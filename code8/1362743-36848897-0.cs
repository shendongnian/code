    [Test]
    public async Task FindAsync_By_Using_Some_Condition()
    {
        var results = await Repository.FindAsync(workClients);
        Assert.AreEqual(2, results.Count);
    }

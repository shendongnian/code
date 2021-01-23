    [Test, ExpectedException(typeof(ArgumentNullException)]
    public async Task NullProcThrows_Async()
    {
        var keyList = new KeyList<int>();
        await keyList.LoadAsync((IDBProcedure)null, "ID", CancellationToken.None);
        Assert.Fail("This should never be executed as we expected the above to throw.");
    }

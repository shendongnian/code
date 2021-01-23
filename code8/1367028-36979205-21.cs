    [TestMethod]
    public void ShouldReturnAllValues()
    {
        int correctAmount = 3; // The number specified in MockUtils.
        var dbContext = MockUtils.GetMockDbSet();
        var repo = new AppBackendRepository(dbContext);
        var result = repo.Get();
        Assert.IsTrue(result.Count() == correctAmount);
    }

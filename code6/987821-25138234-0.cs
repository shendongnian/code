    [TestMethod]
    public void TestMethod1()
    {
        var mock = new Mock<IFileRepository>();
        UnityManager.RegisterInstance<IFileRepository>(mock.Object);
        // ..
    }

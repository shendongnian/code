    [TestMethod]
    public void GetDateTest()
    {
        Mock<IDateServer> server = new Mock<IDateServer>();
        Action<string> callback = (string s) => { };
        IDateManager dm = new DateManager(server.Object);
        dm.GetDate("USDCAD", "2016-02-17", callback);
        server.Verify(x => x.GetValidDate("USDCAD", "2016-02-17", callback));
    }

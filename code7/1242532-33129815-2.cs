    [TestMethod()]
    public void TestMyWork()
    {
        var mockMyData = Mock<IMyData>();
        mockMyData.Setup(x => x.GetMyData()).Returns(new DataTable());
        
        MyWork work = new MyWork(mockMyData);
        int result = work.DoWork();
        Assert.AreEqual(1, result);
    }

    [SetUp]
    public void SetUp()
    {
        _service.Setup(x => x.ProcessInt(It.IsAny<MyObj>())).Returns(1);
    }

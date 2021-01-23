    [SetUp]
    public void SetUp()
    {
        // setup only for cases where obj.Number == 1
        _service
            .Setup(x => x.ProcessInt(It.Is<MyObj>(o => o.Number == 1 )))
            .Returns(1);
        // setup only for cases where obj.Number == 2
        _service
            .Setup(x => x.ProcessInt(It.Is<MyObj>(o => o.Number == 2 )))
            .Returns(2);
    }

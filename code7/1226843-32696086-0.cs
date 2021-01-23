    var myMock = new Mock<IDBCLASS>();
    myMock.SetupSequence(o => o.GETBYType(It.IsAny<Expression<Func<MyObject, bool>>>()))
        .Returns(new MyObject { Id = 999, ParentId = 1000 })
        .Returns(new MyObject { Id = 1000 } )
        .Returns(null);

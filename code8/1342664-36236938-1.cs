    // arrange
    Mock<Test> mock = new Mock<Test>();
    mock.CallBase = true;
    mock.Setup(t => t.Run()).Returns(1);
    // act
    ITest test = mock.Object;
    test.Run();
    // assert
    mock.Verify(t => t.Run(), Times.Once());

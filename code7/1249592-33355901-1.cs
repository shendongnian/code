    // Arrange
    var mock = new Mock<IFoo>();
    mock.Setup(m => m.GetFoos()).Returns(Enumerable.Range(1, 2));
    var sut = new Bar(mock.Object);
    // Act
    var results = sut.SquareFoos().ToList();
    // Assert
    Assert.AreEqual(2, results.Count);

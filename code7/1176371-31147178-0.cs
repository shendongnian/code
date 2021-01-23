    var options = new[] {new Option(...)};
    repositoryMock.Setup(r => r.Context).Returns(contextMock.Object);
    contextMock.Setup(c => c.AsQueryable<Option>()).Returns(options.AsQueryable());
    ...
    Assert.AreEqual(results[0], options[0].Id);

    [Test]
    public void MyTest() {
        var factoryMock = new Mock<ICommandFactory>();
        var commandMock = new Mock<IInsertProjectDAOAction>();
        factoryMock.Setup(x => x.CreateInsertProjectAction(It.IsAny<int>())).Returns(commandMock.Object);
        commandMock.Setup(x => x.Execute()).Throws(new InvalidOperationException("Random failure"));
        var controller = new MyController(factoryMock.Object);
        try {
            controller.Create(/* ... */);
            Assert.Fail();
        }
        catch (InvalidOperationException ex) {
            Assert.AreEqual("Random failure", ex.Message);
        }
    }

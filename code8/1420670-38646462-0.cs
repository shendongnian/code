    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CommandHandlerThrowsCorrectException()
    {
        var handler = new Decorator1(new Decorator2(new MyHandler()));
        handler.Handle(new MyCommand);
    }

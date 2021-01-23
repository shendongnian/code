    [TestMethod]
    public void AssertFooHasAWidget() {
        // Setup 
        var foo = new Foo(); // or better, mocking a Foo
        // Act
        foo.giveWidget();
        // Assert
        Assert.IsTrue(foo.hasWidget()); 
    }

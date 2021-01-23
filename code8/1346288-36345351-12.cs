    [TestMethod]
    public void DoStuff_ReturnsParameterPlusOne()
    {
        // Arrange
        Foo foo = new Foo();
        int passed = 1;
        int expected = passed + 1;
        // Act
        var results = foo.DoStuff(passed);
        // Assert
        Assert.AreEqual(expected, results);
    }

    [TestMethod]
    public void Baz_ReturnsDoStuffValueWithBazAppended
    {
        // Arrange
        int testDoStuffReturn = 1;
        Mock<Foo> mock = new Mock<Foo>();
        mock.CallBase = true;
        mock
            .Setup(s => s.DoStuff(It.IsAny<int>())
            .Returns(testDoStuffReturn);
    
        // Act
        var results = mock.Object.Baz(5);
    
        // Assert
        Assert.AreEqual(string.Format("{0}{1}", results, "Baz"), results); // Validates the result
        mock.Verify(v => v.DoStuff(It.IsAny<int>())); // Verifies that DoStuff was called
    }

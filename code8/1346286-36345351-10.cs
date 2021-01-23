    [TestMethod]
    public void Bar_ReturnsBazValueWithBarAppended
    {
        // Arrange
        string testBazReturn = "test";
        Mock<Foo> mock = new Mock<Foo>();
        mock.CallBase = true;
        mock
            .Setup(s => s.Baz(It.IsAny<int>())
            .Returns(testBazReturn);
        // Act
        var results = mock.Object.Bar();
        // Assert
        Assert.AreEqual(string.Format("{0}{1}", testBazReturn, "Bar"), results);
        mock.Verify(v => v.Baz(It.IsAny<int>())); // Verifies that Baz was called
    }

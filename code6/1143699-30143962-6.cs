    [TestMethod]
    public void TestNpCalculator()
    {
        // Arrange
        var sut = new NpCalculator();
        var values = new int[] { 12, 7, 15, 3 };
        // Act
        float result = sut.CalcNP(values);
        // Assert
        Assert.AreEqual(123.456f, result);
    }

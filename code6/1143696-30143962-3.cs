    [TestMethod]
    public void GütigerFaktorWirdErmittelt()
    {
        // Arrange
        var sut = new NpCalculator();
        var values = new int[] { 12, 7, 15, 3 }
        // Act
        float result = sut.CalculateNP(values);
        // Assert
        Assert.AreEqual(123.456, result);
    }

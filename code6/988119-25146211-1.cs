    [TestMethod]
    public void ZeroCelsiusShouldConvertTo32Fahrenheit() {
        // Given
        float expected 32.0;
        float celsius = 0.0;        
        // When
        var actual = Convert.ToFahrenheit(celsius);
        // Then
        Assert.AreEqual(typeof(float), actual);
        Assert.AreEqual(expected, actual);
    }

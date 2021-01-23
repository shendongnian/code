    using Microsoft.VisualStudio.TestTools.UnitTesting;
    // ...
    [TestMethod]
    public void MyTestMethod()
    {
        // Arrange
        var testClass = new ClassToTest();
        var privateObject = new PrivateObject(testClass);
        // Act
        var output = (int) privateObject.Invoke("Duplicate", 21);
        
        // Assert
        Assert.AreEqual(42, output);
    }

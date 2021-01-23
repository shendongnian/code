    [TestMethod]
    public void TestMethod1() {
        //Arrange
        int a = 5;
        int b = 10;
        int expected = 50;
        var mockMultiplier = new Mock<IMultiply>();
        mockMultiplier.Setup(x => x.Multi(a, b)).Returns(expected);
        //your web form is the system under test
        var webForm = new WebForm1(mockMultiplier.Object);
        //Act
        var actual = webForm.Multi(a, b);
    
        Assert.AreEqual(expected, actual);
    }

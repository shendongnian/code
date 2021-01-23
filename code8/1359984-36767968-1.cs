    [Fact]
    public void TestSampleClass()
    {
        //Arrange
        var testNumber = 5; //Could be what ever number you want to test
        var expected = 200
        var sut = new Sample();
    
        //Act
        sut.Check(testNumber);
        var actual = sut.Number;
    
        //Assert
        Assert.AreEqual(expected, actual);
    }

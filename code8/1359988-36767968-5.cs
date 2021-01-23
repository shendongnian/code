    [Fact]
    public void TestISampleCheck() {
        //Arrange
        var testNumber = 5; //Could be what ever number you want to test
        var expected = 200;
        var mock = new Mock<ISample>();
        //Specifies that the all properties on the mock should have "property behavior",
        //meaning that setting its value will cause it to be saved and later returned
        //when the property is requested. (this is also known as "stubbing"). The default
        //value for each property will be the one generated as specified by the Moq.Mock.DefaultValue
        //property for the mock.
        mock.SetupAllProperties();
                
        var sut = mock.Object;
        mock.Setup(s => s.Check(It.IsAny<int>()))
            .Callback((int a) => {
                if (a > 10) {
                    sut.Number = 100;
                } else {
                    sut.Number = 200;
                }
            });
        //Act
        sut.Check(testNumber);
        var actual = sut.Number;
        //Assert
        Assert.AreEqual(expected, actual);
    }

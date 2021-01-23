    [TestMethod]
    public void TestPostMethod() {
        //Arrange
        IHeaderService headers = new MyFakeHeaderService("FAKE OS TYPE");
        var sut = new MyApiController(headers);
        var model = new TestDTO();
        //Act
        sut.Post(model);
        //Assert
        //.....
    }

    public void TestMyClass() {
        //Arrange
        var mockEnvironment = new Mock<IHostingEnvironment>();
        //...Setup the mock as needed
    
        //create your SUT and pass dependencies
        var sut = new MyClass(mockEnvironment.Object);
    
        //Act
        //...call you SUT
    
        //Assert
        //...assert expectations
    }

    [TestMethod]
    Public void MyClass_MymethodthatcallsGenereateClient_DoesCallGenerateClient()
    {
        // Arrange
        Mock<IClientAuthenticator> clientAuth = new Mock<IClientAuthenticator>();
        MyClass myclass = new MyClass()
        
        // Act
        var result = MyClass.MymethodthatcallsGenereateClient();
    
        // Assert (verify that we really added the client)
        clientAuth.Verify(x => x.GenerateClient);
    }

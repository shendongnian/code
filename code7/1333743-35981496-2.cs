    [TestMethod]
    public void SomeMethod_UserIsAuthenticated_InvokesSomeOtherMethod()
    {
      // Arrange
      GetMockFor<ILoginManager>().SetupGet(lm => lm.Authenticated).Returns(true);
    
      // Act
      var result = Instance.SomeMethod();
    
      // Assert
      GetMockFor<ISomeOtherInterface>()
        .Verify(o => o.SomeOtherMethod(), Times.AtLeastOnce() );
    }

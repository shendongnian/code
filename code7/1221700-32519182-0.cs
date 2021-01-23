    // Arrange
    var are = new AutoResetEvent(false);
    int args = 0;
    
    EventHandler<object, MyEventArgs> handler = (s, e) =>
    {
        args = e.Value;
        are.Set(); 
    };
    
    // Act
    MyClass.SomeMethod(123, handler);
    
    
    // Assert
    var wasCalled = are.WaitOne(timeout: TimeSpan.FromSeconds(1));
    Assert.True(wasCalled);
    Assert.AreEqual(123, args);

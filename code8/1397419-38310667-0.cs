    [TestMethod,Isolated]
    public void TestForHttpContext_willReturn123AsIP()
    {
        // Arrange
        Program classUnderTest = new Program();
        IPAddress[] a = { new IPAddress(long.Parse("123")), new IPAddress(long.Parse("456")), new IPAddress(long.Parse("789")) };
    
        Isolate.WhenCalled(() => HttpContext.Current.Request.UserHostAddress).WillReturn("testIP");
        Isolate.WhenCalled(() => Dns.GetHostAddresses(" ")).WillReturn(a);
    
        // Act
        var res = classUnderTest.getIPAddress();
    
        // Assert
        Assert.AreEqual("123.0.0.0", res);
    }
        

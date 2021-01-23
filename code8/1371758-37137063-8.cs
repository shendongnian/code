    [Test]
    public void GeneratePasswd_PasswdLength_NewPasswd()
    {
        var mockNotifier = new Mock<INotifier>();
        var mockPaswordGenerator = new Mock<IPasswdGenerator>();
    
        var accMgr = new AccountController(mockNotifier.Object, mockPaswordGenerator.Object);
    
        IActionResult result = accMgr.generatePasswd(length);
    
        Assert.IsInstanceOfType(result , typeof(OkResult));    
    }

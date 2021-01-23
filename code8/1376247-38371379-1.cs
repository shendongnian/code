    [TestMethod,Isolated]
    public async void TestMethod1()
    {
        // Arrange
        AccountController controller = new AccountController();
    	// Mocking SignInManager.HasBeenVerifiedAsync()
        Isolate.WhenCalled(() => controller.SignInManager.HasBeenVerifiedAsync()).WillReturn(Task.FromResult(true));
    
    	// Act
        var result = await controller.VerifyCode("tester", "test.com", true) as ViewResult ;
    
    	// Assert
        Assert.AreEqual("tester", (result.Model as VerifyCodeViewModel).Provider);
        Assert.AreEqual("test.com", (result.Model as VerifyCodeViewModel).ReturnUrl);
        Assert.IsTrue((result.Model as VerifyCodeViewModel).RememberMe);
    }

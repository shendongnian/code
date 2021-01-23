    [TestMethod, Isolated]
    public async Task TestWhenEmailIsBad_ErrorMessageIsShown()
    {
        
        // Arrange
        // Create the wanted controller for testing and fake IdentityResult
        var controller = new aspdotNetExample.Controllers.AccountController();
        var fakeIdentityRes = Isolate.Fake.Instance<IdentityResult>();
        
    	// Fake HttpContext to return a fake ApplicationSignInManager
        var fakeSIM = Isolate.WhenCalled(() => controller.UserManager).ReturnRecursiveFake();
       
        // Modifying the behavior of ConfirmEmailAsync to return fakeIdentityRes
        Isolate.WhenCalled(() => fakeSIM.ConfirmEmailAsync("", "")).WillReturn(Task.FromResult<IdentityResult>(fakeIdentityRes));
        Isolate.WhenCalled(() => fakeIdentityRes.Succeeded).WillReturn(false);
        
    	// Act
        var result = await controller.ConfirmEmail("", "") as ViewResult;
    
        // Assert
        Assert.AreEqual("Error", result.ViewName);
    }    

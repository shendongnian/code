    [TestMethod, Isolated]
    public async Task TestWhenLoginIsBad_ErrorMessageIsShown()
    {
        // Arrange
        // Create the wanted controller for testing 
        var controller = new AccountController(); 
        var loginData = new LoginViewModel { Email = "support@typemock.com", Password = "password", RememberMe = false };
       
        // Fake the ModelState
        Isolate.WhenCalled(() => controller.ModelState.IsValid).WillReturn(true);
     
        // Ignore AddModelError (should be called when login fails)
        Isolate.WhenCalled(() => controller.ModelState.AddModelError("", "")).IgnoreCall();
        
        // Fake HttpContext to return a fake ApplicationSignInManager
        var fakeASIM = Isolate.WhenCalled(() => controller.HttpContext.GetOwinContext().Get<ApplicationSignInManager>()).ReturnRecursiveFake();
        
        // When password checked it will fail. Note we are faking an async method
        Isolate.WhenCalled(() => fakeASIM.PasswordSignInAsync(null, null, true, true)).WillReturn(Task.FromResult(SignInStatus.Failure));
        
        // Act
        var result = await controller.Login(loginData, "http://www.typemock.com/");
    
        // Assert
        // The result contains login data, doesn’t redirect
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        Assert.AreSame(loginData, (result as ViewResult).Model);
        // Make sure that the code added an error
        Isolate.Verify.WasCalledWithExactArguments(() => controller.ModelState.AddModelError("", "Invalid login attempt."));
    }

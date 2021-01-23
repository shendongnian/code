    [TestClass]
    public class AccountControllerTest
    {
    [TestMethod]
    public void AccountController_Register_UserRegistered()
    {
        var accountController = new AccountController();
        var registerViewModel = new RegisterViewModel
        {
            Email = "test@test.com",
            Password = "123456"
        };
 
        var result = accountController.Register(registerViewModel).Result;
        Assert.IsTrue(result is RedirectToRouteResult);
        Assert.IsTrue( _accountController.ModelState.All(kvp => kvp.Key != "") );
    }}

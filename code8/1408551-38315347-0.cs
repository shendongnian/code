    // orchestrates login user action
    interface ILoginActions
    {
        // logs in the user and returns a reference to the account settings page
        // which appears after successful login
        IAccountSettings Login(string username, string password);
    }
    
    public class LoginActions : ILoginActions
    {
        public readonly ILoginPage loginPage;
        public LoginActions(ILoginPage loginPage)
        {
            this.loginPage = loginPage;
        }
        public IAccountSettings Login(string username, string password)
        {
            // the orchestrator does not typically need to make assertions,
            // and can assume that there are tests for Login actions
            stopWatch.Start();
            
            var model = 
            this.loginPage
                .Username.SetValue(username)
                .Password.SetValue(password)
                .Login.Click();
            stopWatch.Stop();
       
            log("Login Timing", stopWatch.Elapsed);
            return model;
        }
    }

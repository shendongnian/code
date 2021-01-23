    public class App : Application
    {
        public App()
        {
            var loginPage = new LoginPage();
            loginPage.LoginSucceeded += HandleLoginSucceeded;
            MainPage = loginPage;
        }
    
        private void HandleLoginSucceeded(object sender, EventArgs e)
        {
            MainPage = new MainPage();
        }
    }

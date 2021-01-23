    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.StartLoginWindowService();
        }
    }

    public class MainViewModel 
    {
        //INPC omitted for brevity
        public object CurrentViewModel { get; private set; }
    
        public void MainViewModel()
        {
            this.CurrentViewModel = new LoginViewModel(LoginComplete);
        }
    
        private void LoginComplete()
        {
            this.CurrentViewModel = new NavigationViewModel();
        }
    }
    
    public class LoginViewModel 
    {
        private Action loginCompleteAction;
    
        public void LoginViewModel(Action loginCompleteAction)
        {
            this.loginCompleteAction = loginCompleteAction;
        }
    
        private void UserHasLoggedIn()
        {
            this.loginCompleteAction();
        }
    }

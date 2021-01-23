    public class LoginPage : ContentPage
    {
        public event EventHandler LoginSucceeded;
    
        public event EventHandler LoginFailed;
    
        private void OnLoginSucceeded()
        {
            if (LoginSucceeded != null)
            {
                LoginSucceeded(this, EventArgs.Empty);
            }
        }
    
        private void OnLoginFailed()
        {
            if (LoginFailed != null)
            {
                LoginFailed(this, EventArgs.Empty);
            }
        }
    }

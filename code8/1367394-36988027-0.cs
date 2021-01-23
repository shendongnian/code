     class WindowsService
    {
        private static LoginWindow loginWindow{ get; set; }
        private static UserWindow UserWindow{ get; set; }
        public void ShowLoginWindow(LoginViewModel loginViewModel)
        {
            LoginWindow = new LoginWindow 
            {
                DataContext = loginViewModel
            };
            LoginWindow.Show();
        }
        public void ShowUserWindow(UserViewModel userViewModel)
        {
            UserWindow = new UserWindow 
            {
                DataContext = userViewModel
            };
            
            LoginWindow .Hide();
            UserWindow.Show();
        }
    }

    public class DatabaseConfigurationViewModel
    {
        public DatabaseConfigurationViewModel()
        {
            CurrentLoginData = new LoginData(true);
        }
        public LoginData CurrentLoginData { get; set; }
    }

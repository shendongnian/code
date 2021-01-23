    namespace YourApp.ViewModels
    {
        public class LoginViewModel
        {
            public HaveLoginData RegionData { get; set; }
    
            public void Login()
            {
                // do the second login conditions logic
                if (true)
                {
                    RegionData.Login = "new user login";
                }
            }
        }
    }

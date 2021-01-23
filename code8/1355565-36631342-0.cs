    public class LoginFragment : Fragment
    {
        Action _onLoggedIn;
    
        public static void NewInstance(Action onLoggedIn)
        {
            var fragment = new LoginFragment();
            fragment._onLoggedIn = onLoggedIn;
    
            return fragment;
        }
    
        private void Login()
        {
            // login user
            // after loggedin
            _onLoggedIn?.Invoke();
        }
    }

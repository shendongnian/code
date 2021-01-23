    public class PasswordPool
    {
        private static Dictionary<string, string> _Passwords;
        
        private static void InitPasswords()
        {
            _Passwords = new Dictionary<string, string>();
            _Passwords.Add("User1", "Password");
            _Passwords.Add("User2", "Password");
            _Passwords.Add("User3", "Password");
        }
        
        public static string GetPassword(string userName)
        {
            if (_Passwords == null)
                InitPasswords();
            
            string password;
            
            if (_Passwords.TryGetValue(userName, out password))
                return password;
            
            // handle case when password for specified userName not found
            // Throw some exception or just return null
            
            return null;
        }
    }

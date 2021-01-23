    public class Authentication
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public Authentication()
        {
            dictionary.Add("username1", "password1");
            dictionary.Add("username2", "password2");
            dictionary.Add("username3", "password3");
            dictionary.Add("username4", "password4");
            dictionary.Add("username5", "password5");
        }
        public bool Authenticate(string user, string password)
        {
            // note i just replaced the variable with return
            return dictionary.ContainsKey(user) && dictionary[user] == password;
        }
    }

        public bool Authenticate(string user, string password)
        {
            bool authenticated = false;
            if (dictionary.ContainsKey(user) && dictionary[user] == password)
            {
                authenticated = true;
            }
            else
            {
                authenticated = false;
            }
            return authenticated;
        }

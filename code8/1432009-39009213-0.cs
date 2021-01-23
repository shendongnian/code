        public bool AuthUser(string user, string pass)
        {
            // here you will need to hash the password using
            // the same function as when the user was created
            string hash = some_function(pass);
            var user = from user in db.AspNetUsers 
                       where user.Email == user &&
                       user.PasswordHash == hash
                       select user;
            
            // found a matching user
            if (user != null) return true;
            // did not find a match
            return false;
        }

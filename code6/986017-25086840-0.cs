    public static async Task<bool> isAuthenticated(string Username, string Password)
    {
        return await Task.Factory.StartNew<bool>(()=>{
        //Open a connection with the database
        using (WHDataDataContext db = new WHDataDataContext())
        {
            //Compare the Username and the password and return the result
            return db.Users.Any(check => check.Username == Username && check.Password    == Cryptographer.Encrypt(Password));
        }
        }
    }

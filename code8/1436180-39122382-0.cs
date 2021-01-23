    public bool getUserPassword(string username, string password)       
    {   
        string hashPassword= (from u in db.AspNetUsers
                            where u.UserName.Equals(username)
                            select u.PasswordHash).ToString();
        //Get the salt from the hashed password and use it to hash the user given password
        //Then verify that both the passwords match and check the result with the PasswordVerificationResult enum
        if (UserManager.PasswordHasher.VerifyHashedPassword(hashPassword, password) != PasswordVerificationResult.Failed)
            return true;
        else
            return false;
    }

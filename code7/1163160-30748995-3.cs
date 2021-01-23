    public bool Authenticate(username, password)
    {
        User user = // Get user info  -> Users.SelectSingle(x=>x.Username.Equals(username))
        string calculatedHash = GeneratePasswordHash(password, user.Salt);
        return user.HashedPassword.Equals(calculatedHash);
    }

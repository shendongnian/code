	public Boolean VerifyPassword(string userName, string password)
    {
        return soccerEntities.Users
            .Any(u => u.UserName == userName
                         && u.password == password);
    }

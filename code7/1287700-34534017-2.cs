    public Task<string> GetPasswordHashAsync(RegisteredUser user)
    {
        string passwordHash = AWSUser.GetPasswordHash(user.Id);
        return Task.FromResult(passwordHash);
    }

    public Task SetPasswordHashAsync(User user, string passwordHash)
    {
        user.PasswordHash = passwordHash;
        return Task.FromResult(0);
    }

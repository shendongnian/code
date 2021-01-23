    public Task<ClaimsIdentity> CreateIdentity(string userid )
    {
        Guid gid = Guid.Parse(userid);
        return _dbContext.Users.Where(d => d.Id == gid).FirstOrDefaultAsync().
            ContinueWith(avatarTask => CreateIdentity(avatarTask.GetAwaiter().GetResult()));
    }

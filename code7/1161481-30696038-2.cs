    public async Task<ClaimsIdentity> CreateIdentity(string userid )
    {
        Guid gid = Guid.Parse(userid);
        Avatar avatar = await _dbContext.Users.Where(d => d.Id == gid).FirstOrDefaultAsync();
        var claims = new List<Claim>(); 
        claims = async //(database call to get claims) 
        return new ClaimsIdentity(claims);
    }

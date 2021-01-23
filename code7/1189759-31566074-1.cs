    public override Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return Task.Run(() => MyCheckPasswordAsync());
    }
    
    private bool MyCheckPasswordAsync()
    {
        return true;
    }

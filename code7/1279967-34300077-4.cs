    public async Task<User> GetAsync(string email)
    {
        try
        {
            // go to database here, and get the User
            return new User();
        }
        catch
        {
            // log exception
            throw;
        }
    }

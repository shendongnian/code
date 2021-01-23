    public async Task CreateAsync(TUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException("user");
        }
    
        var existingUser = await this.FindByIdAsync(user.Id);
        if (existingUser != null)
        {
            await this.UpdateAsync(user);
        }
        else
        {
            userTable.Insert(user);
        }
    }

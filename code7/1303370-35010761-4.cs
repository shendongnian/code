    public async Task<TUser> FindByIdAsync(int userId)
    {
       var tResult = userTable.GetUserByIdAsync(userId);
       TUser result = null;
       try
       {
         result = await tResult;
       } 
       except
       {
         // Bad idea, but here goes to your first snippet
       }
       return Task.FromResult<TUser>(result);
    }

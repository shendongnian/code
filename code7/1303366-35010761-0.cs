    public async Task<TUser> FindByIdAsync(int userId)
    {
       var tResult = userTable.GetUserByIdAsync(userId);
       TUser result = null;
       try
       {
         var result = await tResult;
       } 
       finally 
       {
         return Task.FromResult<TUser>(result);
       }
    }

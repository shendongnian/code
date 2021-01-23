    private class UserService
    {
        public async Task<IdentityUser> GetByIdAsync(int id)
        {
            return await mContext.Users.SingleAsync(u => u.Id == id);
        }
    }

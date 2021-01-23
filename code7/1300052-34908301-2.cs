    private class UserService
    {
        public IdentityUser GetById(int id)
        {
            return mContext.Users.Single(u => u.Id == id);
        }
    }

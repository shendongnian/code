    public class UserService : IUserService
    {
        public User getUserByUID(string uid)
        {
            UserDAO mUserDAO = UserService.getUserDAO();
            User mUser = mUserDAO.getUserByUID(Convert.ToInt64(uid));
            if (mUser != null)
            {
                mUserDAO.close();
                return mUser;
            }

    public class UserRepository : IUserRepository, IDisposable
    {
        private PrincipalContext _pc;
        private UserPrincipalExtension _user;
        private PrincipalSearcher _ps;
        public UserRepository()
        {
            _pc = MyUtilities.GetPrincipalContext(ouPath);
            _user = new UserPrincipalExtension(pc);
            _ps = new PrincipalSearcher(user);
        }
        public List<MyUser> GetUsersInOU(string ouPath)
        {
            List<MyUser> users = new List<MyUser>();
        
            user.Enabled = true;
            foreach (UserPrincipalExtension u in _ps.FindAll())
            {
                users.Add(MyUser.Load(u.SamAccountName));
            }
        
            return users;
        }
        public void Dispose()
        {
           _ps.Dispose();
           _user.Dispose();
           _pc.Dispose();
        }
    }

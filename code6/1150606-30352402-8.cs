        public class UserManager : IUserManager
    {
        private readonly UserManager<User> _identityManager;
        public UserManager(ClaimsFactory claimsFactory, IdentityDataContext context, IdentityValidator identityValidator)
        {
            _identityManager = new UserManager<User>(new UserStore<User>(context))
                               {
                                   ClaimsIdentityFactory = claimsFactory,
                                   UserValidator = identityValidator
                               };
        }
        public void Register(User user, string password)
        {
            var result = _identityManager.Create(user, password);
            if (!result.Succeeded)
                throw new ApplicationException("User can not be created. " + result.Errors.FirstOrDefault());
        }
        public void Register(User user)
        {
            var result = _identityManager.Create(user);
            if (!result.Succeeded)
                throw new ApplicationException("User can not be created. " + result.Errors.FirstOrDefault());
        }
        public User Find(string userName, string password)
        {
            return _identityManager.Find(userName, password);
        }
        public ClaimsIdentity CreateIdentity(User user, string applicationCookie)
        {
            return _identityManager.CreateIdentity(user, applicationCookie);
        }
        public User FindByUserName(string userName)
        {
            return _identityManager.FindByName(userName);
        }
        public bool ChangePassword(string identifier, string oldPassword, string newPassword)
        {
            return _identityManager.ChangePassword(identifier, oldPassword, newPassword).Succeeded;
        }
        public bool ResetPassword(string userName, string password)
        {
            try
            {
                var user = FindByUserName(userName);
                var result = _identityManager.RemovePassword(user.Id);
                if (result != IdentityResult.Success)
                    return false;
                result = _identityManager.AddPassword(user.Id, password);
                return result == IdentityResult.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User FindById(string userId)
        {
            return _identityManager.FindById(userId);
        }
        public bool IsInRole(string userId, string role)
        {
            return _identityManager.IsInRole(userId, role);
        }
        public void AddToRole(string userId, string role)
        {
            _identityManager.AddToRole(userId, role);
        }
    }

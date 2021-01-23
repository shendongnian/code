    internal class UserManagerWrapper
    {
        private readonly IEditUserResponceDataModelProvider _editUserResponceDataModelProvider;
        private readonly UserManager<User> _userManager;
        private readonly IUserModelFactory _userModelFactory;
        public UserManagerWrapper(UserManager<User> userManager,
            IUserModelFactory userModelFactory,
            IEditUserResponceDataModelProvider editUserResponceDataModelProvider)
        {
            _userManager = userManager;
            _userModelFactory = userModelFactory;
            _editUserResponceDataModelProvider = editUserResponceDataModelProvider;
        }
        public async Task<IUserModel> FindByIdAsync(string id)
        {      
            var user = await _userManager.FindByIdAsync(id);
            return _userModelFactory.Create(user.Id, user.Email, user.Year, user.UserName);
        }
	}

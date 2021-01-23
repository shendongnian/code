    public class UserViewModel
    {
        private readonly User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }
        public int UserID
        {
            get { return _user.UserID; }
        }
        public string FirstName
        {
            get { return _user.FirstName; }
        }
    }
    ...
    var viewModels = userRepository.GetUsers().Select(user => new UserViewModel(user));

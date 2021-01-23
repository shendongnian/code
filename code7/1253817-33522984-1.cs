    public class UserListViewModel : ViewModelBase
    {
        private User _user;
        private ObservableCollection<string> _userList; // changed from "User" class to string
        public User user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("user");
            }
        }
        public ObservableCollection<string> userList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                OnPropertyChanged("userList");
            }
        }
        public UserListViewModel()
        {
            userList = new ObservableCollection<string>();
            Task.Run(async () => this.userList = await getUserList()); // Credit to gilMishal
        }
        public async Task<ObservableCollection<string>> getUserList()
        {
            var UserListRaw = await User.getUserList();
            var userListOC = new ObservableCollection<string>();
            foreach (var doc in UserListRaw) // extracting the "name" property from each "User" object
            {
                userListOC.Add(doc.name);
            }
            return userListOC;
        }
    }

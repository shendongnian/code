    public class FriendlistViewModel : BaseObservableObject
    {
        private ObservableCollection<FriendlistPart> _friendsCompleteList;
        public FriendlistViewModel(List<FriendlistPart> friendsCompleteList)
        {
            FriendsCompleteList = new ObservableCollection<FriendlistPart>(friendsCompleteList);
        }
        public ObservableCollection<FriendlistPart> FriendsCompleteList
        {
            get { return _friendsCompleteList; }
            set { Set(ref _friendsCompleteList, value); }
        }
    }
    public class FriendlistPart:BaseObservableObject
    {
        private string _letter;
        private ObservableCollection<User> _friends;
        public string Letter
        {
            get { return _letter; }
            set
            {
                _letter = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<User> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                OnPropertyChanged();
            }
        }
    }
    public class User:BaseObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
    }
    public class MainViewModel : BaseObservableObject
    {
        private FriendlistViewModel _currentPageViewModel;
        public MainViewModel()
        {
            var userList = new ObservableCollection<User>
            {
                new User {Username = "test"},
                new User {Username = "test1"},
                new User {Username = "test2"}
            };
            var userList1 = new ObservableCollection<User>
            {
                new User {Username = "test3"},
                new User {Username = "test4"},
                new User {Username = "test2"},
                new User {Username = "test5"},
                new User {Username = "test6"},
                new User {Username = "test7"},
                new User {Username = "test8"},
            };
            var userList2 = new ObservableCollection<User>
            {
                new User {Username = "test9"},
                new User {Username = "test10"},
            };
            var friendlistCompleteList = new List<FriendlistPart>
            {
                new FriendlistPart {Friends = userList, Letter = "A"},
                new FriendlistPart {Friends = userList1, Letter = "B"},
                new FriendlistPart {Friends = userList2, Letter = "C"}
            };
            CurrentPageViewModel = new FriendlistViewModel(friendlistCompleteList);
        }
        public FriendlistViewModel CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }
    }

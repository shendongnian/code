    public class ViewModel
    {
        public ViewModel()
        {
            Users = new ObservableCollection<User>
            {
                new User { Id = 1, Name = "John" },
                new User { Id = 2, Name = "Mary" },
                new User { Id = 3, Name = "Peter" },
                new User { Id = 4, Name = "John" },
                new User { Id = 5, Name = "John" },
                new User { Id = 5, Name = "Peter" }
            };
            UsersView = new ListCollectionView(Users)
            {
                Filter = obj =>
                {
                    var user = (User)obj;
                    return SelectedUser != null && user.Name == SelectedUser.Name && user.Id != selectedUser.Id;
                }
            };
        }
        public ObservableCollection<User> Users { get; private set;  }
        public ICollectionView UsersView { get; set; }
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    UsersView.Refresh();
                }
            }
        }
        private User selectedUser;
    }

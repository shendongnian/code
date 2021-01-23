    public class MainWindowViewModel 
    {
        private User _user;
        public MainWindowViewModel()
        {
            MyCommand = new DelegateCommand(() =>
            {
                //Here you can access to User.Id, User.Name or anything from here
            });
        }
        public DelegateCommand MyCommand { get; private set; }
        public User User
        {
            get { return _user; }
            set
            {
                if (value == _user) return;
                _user = value;
                OnPropertyChanged();
            }
        }
    }

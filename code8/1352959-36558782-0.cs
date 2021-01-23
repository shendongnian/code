    private ObservableCollection<UserViewModel> _users =
        new ObservableCollection<UserViewModel>();
    ObservableCollection<UserViewModel> Users {
        get { return _users; }
        set {
            _users = value;
            //  Implementations of this are everywhere on Google, very simple. 
            OnPropertyChanged("Users");
            //  Or in C#6
            //PropertyChanged?.Invoke(new PropertyChangedEventArgs(nameof(Users)));
        }
    }

    ...
    public UserModel TemporarySelectedUser { get; private set; }
    ...
    TemporarySelectedUser = new UserModel(); // once in the constructor.
    ...
    private UserModel _currentUser;
    public UserModel CurrentUser
    {
        get { return _currentUser; }
        set
        {
            _currentUser = value;
            if (value != null)
                value.CopyTo(TemporarySelectedUser);
            RaisePropertyChanged("CurrentUser");
        }
    }
    ...
    private ICommand _saveCommand;
    public ICommand SaveCommand
    {
        get
        {
            return _saveCommand ??
                    (_saveCommand = new Command<UserModel>(SaveExecute));
        }
    }
    public void SaveExecute(UserModel updatedUser)
    {
        UserModel oldUser = Users[
            Users.IndexOf(
                Users.First(value => value.Id == updatedUser.Id))
            ];
        // updatedUser is always TemporarySelectedUser.
        updatedUser.CopyTo(oldUser);
    }
    ...

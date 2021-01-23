    public User CurrentSelectedUser
    {
        get { return _user; }
        set
        {
            if (value != null)
            {
                UserId = value.UserId;
                FirstName = value.FirstName;
                LastName = value.LastName;
                Username = value.Username;
                Password = value.Password;
                UserTypeId = value.UserTypeId;
            }
            else
            {
                 UserId = -1;// or other "NO USER" condition
                 //etc etc
            }
            OnPropertyChanged("CurrentSelectedUser");
        }
    }

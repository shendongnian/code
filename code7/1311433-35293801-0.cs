    public User CurrentSelectedUser
        {
            get { return _user; }
            set
            {
                UserId = value.UserId;
                FirstName = value.FirstName;
                LastName = value.LastName;
                Username = value.Username;
                Password = value.Password;
                UserTypeId = value.UserTypeId;
                OnPropertyChanged("CurrentSelectedUser");
            }
        }

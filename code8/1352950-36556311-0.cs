    class Base_ViewModel : INotifyPropertyChanged
    {
        public RelayCommand<UserViewModel> editButton_Click_Command { get; set; }
        public Base_ViewModel()
        {
            editButton_Click_Command = new RelayCommand<UserViewModel>(OneditButton_Click_Command);
            this.Users = new ObservableCollection<UserViewModel>();
            this.Users.Add(new UserViewModel() { FirstName = "John", LastName = "Doe", EMail = "JohnDoe@yahoo.com", EndDate = "02-01-2016", Position = "Developer", UserID = "AADD543" });
        }
        private ObservableCollection<UserViewModel> _Users;
        public ObservableCollection<UserViewModel> Users
        {
            get { return _Users; }
            set { _Users = value; NotifyPropertyChanged("Users"); }
        }
        private void OneditButton_Click_Command(UserViewModel obj)
        { // put a break-point here and you will see the data you want to Edit in obj
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

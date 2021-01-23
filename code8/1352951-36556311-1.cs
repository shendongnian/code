    public class UserViewModel : INotifyPropertyChanged
    {
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; NotifyPropertyChanged("FirstName"); }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; NotifyPropertyChanged("LastName"); }
        }
        private string _EMail ;
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; NotifyPropertyChanged("EMail"); }
        }
        private string _UserID;
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; NotifyPropertyChanged("UserID"); }
        }
        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; NotifyPropertyChanged("Position"); }
        }
        private string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; NotifyPropertyChanged("EndDate"); }
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

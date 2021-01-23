    public enum UserStatus { Unknown, Online, Offline, Away, Busy }
    
    class User : INotifyPropertyChanged 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public Image StatusImage;
    
        private UserStatus status = UserStatus.Unknown;
        public UserStatus Status 
        { 
            get{return status;}
            set{
                if (value != status)
                {
                    status=value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public override string ToString()
        {
             return string.Format("{0}, {1}: {2}", LastName, FirstName, Status);
        }
    
    }

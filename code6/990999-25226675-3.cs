    class ViewModel : INotifyPropertyChanged
    {
        private bool credntialsAreValid;
        public bool CredentialsAreValid 
        { 
            get { return this.credentialsAreValid; }
            set 
            {
                 this.credentialsAreValid = value;
                 OnPropertyChanged(); 
            }
        }
    }

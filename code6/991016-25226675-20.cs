    // ViewModel
    class ViewModel : INotifyPropertyChanged
    {
        private bool credentialsAreValid;
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

    // ViewModel
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool credentialsAreValid;
        public bool CredentialsAreValid 
        { 
            get { return this.credentialsAreValid; }
            set 
            {
                 this.credentialsAreValid = value; 
                 OnPropertyChanged(); // Not implemented.
            }
        }
    }

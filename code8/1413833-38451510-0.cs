        private string message;
        public string Message 
        {
            get
            {
                return message;
            }
            set
            {
                   message = value;
                   NotifyPropertyChanged("Message");
            }

    private string _message;
        public string Logger
        {
            get 
            {
                if (_message == null)
                {
                    _message = Logger.GetMessage();
                }
                return _message; }
            set
            {
                _message = value;
                Instance.OnPropertyChanged();
            }
        }

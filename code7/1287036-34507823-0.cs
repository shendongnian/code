        private bool _isPostRequest;
        public bool IsPostRequest
        {
            get { return _isPostRequest; }
            set
            {
                _isPostRequest = value;
                Parameters.ToList().ForEach(x => x.IsPostParameter = value);
                RaisePropertyChanged("IsPostRequest");
            }    
        }

        private bool _isConnectionAvailable;
        public bool IsConnectionAvailable
        {
            get { return _isConnectionAvailable; }
            set
            {
                if (_isConnectionAvailable != value)
                {
                    _isConnectionAvailable = value;
                    NotifyOfPropertyChange(() => IsConnectionAvailable);
                }
            }
        }

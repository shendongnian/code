        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                IsPasswordPlaceholderVisible = string.IsNullOrEmpty(_password);
            }
        }
        public bool IsPasswordPlaceholderVisible
        {
            get { return _isPasswordPlaceholderVisible; }
            set
            {
                if (value.Equals(_isPasswordPlaceholderVisible)) return;
                _isPasswordPlaceholderVisible = value;
                OnPropertyChanged();
            }
        }

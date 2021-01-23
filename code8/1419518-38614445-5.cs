        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
            }
        }
        public bool IsPasswordWatermarkVisible
        {
            get { return _isPasswordWatermarkVisible; }
            set
            {
                if (value.Equals(_isPasswordWatermarkVisible)) return;
                _isPasswordWatermarkVisible = value;
                OnPropertyChanged();
            }
        }

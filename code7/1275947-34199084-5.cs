    private bool _isBrightnessAndContrastEnabled;
        public bool IsBrightnessAndContrastEnabled
        {
            get { return _isBrightnessAndContrastEnabled; }
            set
            {
                _isBrightnessAndContrastEnabled = !IsBrightnessAndContrastEnabled;
                OnPropertyChanged();
            }
        }

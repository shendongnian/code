      private bool _isToggleButtonChecked = false;
        public bool IsToggleButtonChecked
        {
            get { return _isToggleButtonChecked; }
            set { Set<bool>(ref _isToggleButtonChecked, value); }
        }

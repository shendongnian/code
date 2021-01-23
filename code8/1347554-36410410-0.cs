        private TimeSpan? _selectedParkDuration;
        public TimeSpan? SelectedParkDuration
        {
            get
            {
                return this._selectedParkDuration;
            }
    
            set
            {
                if (_selectedParkDuration != value)
                {
                    _selectedParkDuration = value;
                    RaisePropertyChanged("SelectedParkDuration");
                }
            }
        }

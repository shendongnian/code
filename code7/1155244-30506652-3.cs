        private bool _showLegendPopup;
        public bool ShowLegendPopup
        {
            get
            {
                return _showLegendPopup;
            } 
            set
            {
                _showLegendPopup = value;
                OnPropertyChanged();
            }
        }
        public ICommand PopupClosingCommand { get; private set; }
      
        private void InitialiseCommands()
        {
            PopupClosingCommand =  new DelegatingCommand(PopupClosing);
        }
        private void PopupClosing()
        {
            ShowLegendPopup = false;
        }

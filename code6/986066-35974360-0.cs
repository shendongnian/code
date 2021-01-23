    puclic class Payment : INotifyPropertyChanged
    {
        private int _amountDecimals;
        public int AmountDecimals
        {
            get
            {
                return _amountDecimals;
            }
            set
            {
                if (value <= 100)
                {
                    _amountDecimals = value;
                }
                OnPropertyChanged();
            }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class RegionSaleNew : INotifyPropertyChanged
    {
        DateTime DateSale;
        double _uk;
        .....
        public double UK
        {
            get { return _monitor; }
            set
            {
                if (value == _uk) return;
                _uk = value;
                OnPropertyChanged();
            }
        }
        // Add all properties here
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

        private Nullable<System.DateTime> _invoiceDate;
        public Nullable<System.DateTime> InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                _invoiceDate = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

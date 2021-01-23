		private BindableCollection<Payments>_paymentCollection;
		public BindableCollection<Payments> paymentCollection {
			get { return _paymentCollection; }
			set {
				_paymentCollection = value;
				OnPropertyChanged("paymentCollection");
			}
		}
		protected void OnPropertyChanged(string name) {
			PropertyChangedEventHandler handler = PropertyChanged;
			if(handler != null) {
				handler(this, new PropertyChangedEventArgs(name));
			}
		}

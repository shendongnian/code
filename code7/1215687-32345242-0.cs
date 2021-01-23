    		private ObservableCollection<Things> theThings= new ObservableCollection<Things>();
		public ObservableCollection<Things> TheThings
		{
			get { return this.theThings; }
			set
			{
				this.theThings= value;
				RaisePropertyChanged(); // <-- something like this
            }
        }

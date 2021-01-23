		private ObservableCollection<string> _directories;
		public ObservableCollection<string> Directories
		{
			get
			{
				// auto-initialize
				if (this._directories == null)
					this._directories = new ObservableCollection<string>();
				return this._directories;
			}
			set
			{
				// INPC
				this._directories = value;
				RaisePropertyChanged("Directories");
			}
		}

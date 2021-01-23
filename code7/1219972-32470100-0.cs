		private string _Header;
		public string Header
		{
			get { return this._Header; }
			set { this._Header = value; RaisePropertyChanged(() => this.Header); }
		}

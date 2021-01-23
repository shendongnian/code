		private UserViewModel _User;
		public UserViewModel User
		{
			get { return this._User; }
			set { this._User = value; RaisePropertyChanged(); }
		}

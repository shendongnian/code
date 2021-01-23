		private DoubleCollection _Dashes = new DoubleCollection { 1, 2 };
		public DoubleCollection Dashes
		{
			get { return this._Dashes;}
			set { this._Dashes = value; RaisePropertyChanged(); }
		}

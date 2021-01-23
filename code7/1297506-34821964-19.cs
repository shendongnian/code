		private PageType _CurrentPage;
		public PageType CurrentPage
		{
			get { return _CurrentPage; }
			set { _CurrentPage = value; RaisePropertyChanged(); }
		}

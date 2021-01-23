        private DateTime _date = DateTime.Today;
		public DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
				RaisePropertyChanged(() => Date);
			}
		}

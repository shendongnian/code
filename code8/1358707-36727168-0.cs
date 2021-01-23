    private sample _Item;
		public sample Item
		{
			get
			{
				return _Item;
			}
			set
			{
				if (_Item != value)
				{
					_Item = value;
					OnPropertyChanged("Item");
				}
			}
		}

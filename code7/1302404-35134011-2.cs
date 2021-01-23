			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged("CanModify");
				NotifyPropertyChanged("Orders");
			}
		}
	private OrderVM _selectedorder;
        public OrderVM SelectedOrder
        {
            get
            {
                return _selectedorder;
            }
            set
            {
                _selectedorder = value;
                NotifyPropertyChanged();
            }
        }
    }

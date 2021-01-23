        ...
        private ObservableCollection<ServiceCost> _serviceCosts;
		public ObservableCollection<ServiceCost> ServiceCosts
		{
			get { return _serviceCosts; }
			set { if (_serviceCosts != value){_serviceCosts = value;	DynamicOnPropertyChanged();}}
		}
		private ServiceCost _selectedServiceCost;
		public ServiceCost SelectedServiceCost
		{
			get { return _selectedServiceCost; }
			set
			{ 
				if (_selectedServiceCost != value)
				{
					// This is what I needed access to:  do something here!.
					_selectedServiceCost = value;
					DynamicOnPropertyChanged(); 
				}
			}
		}
        ...

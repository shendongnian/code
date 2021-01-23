    ObservableCollection<KPI> _KPIs;
	public ObservableCollection<KPI> KPIs
	{
		get { return _KPIs; }
		set
		{
			_KPIs = value;
			RaisePropertyChanged("KPIs");
		}
	}

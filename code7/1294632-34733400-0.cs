	private ObservableCollection<License> licenses;
	public ObservableCollection<License> Licenses
	{
		get { return licenses ?? (licenses = CreateLicensesCollection()); }
		set
		{
			Console.Write("Modified");
			Set(ref licenses, value);
			RaisePropertyChanged(nameof(LicensesCount));
		}
	}
	private ObservableCollection<License> CreateLicensesCollection()
	{
		var collection = new ObservableCollection<License>();
		collection.CollectionChanged += (s, a) => RaisePropertyChanged(nameof(LicensesCount));
		return collection;
	}

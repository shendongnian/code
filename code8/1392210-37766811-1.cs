    private Task _initTask;
    public MainWindowViewModel() : base()
    {
      _initTask = InitAsync();
      ...
    }
    private async Task InitAsync()
    {
      PatientList = await GetPatientList();
      ...
    }
    private async Task<ObservableCollection<ViewPatient>> GetPatientListFromName(string lastname, string firstname, string birthdate)
    {
      ...
      string last = lastname ?? string.Empty;
      string first = firstname ?? string.Empty;
      // Ensure PatientList is loaded.
      await _initTask;
      var z = PatientList.Where...
    }

    public NotifyTask<ObservableCollection<ParametersViewModel>>
        Parameters { get; private set { /* with notify, such as RaisePropertyChanged() */ } }
    public MyViewModel()
    {
      Parameters = NotifyTask.Create(() => GetParametersAsync(),
          new ObservableCollection<ParametersViewModel>());
      // Other code...
    }
    private async Task<ObservableCollection<ParametersViewModel>> GetParametersAsync()
    {
      var service = new MyDataService();
      var result = new ObservableCollection<ParametersViewModel>();
      foreach(var parameter in await service.GetParameters())
          result.Add(parameter);
      return result;
    }

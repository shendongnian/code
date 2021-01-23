    public DetailViewModel(INavigationService navigationService)
    {
      InitializeAsync();
    }
    private Task InitializeAsync()
    {
      try
      {
        DataList = await Task.Run(() => GetData());
      }
      catch
      {
        // TODO: Log
      }
    }
    private List<Data> GetData()
    {
      using (var context = new MyDataContext())
      {
        return context.Data.ToList();
      }
    }

    public MyViewModel()
    {
      MyData = NotifyTask.Create(LoadDataAsync());
    }
    public NotifyTask<TMyData> MyData { get; }

    public async void Methodasync()
    {
      var progress = new Progress<int>(value =>
      {
        count = value;
        onPropertyChanged("count");
      });
      await Method(progress);
    }
    public Task Method(IProgress<int> progress)
    {
      return Task.Run(() =>
      {
        for (int i = 0; i < 100; i++)
        {
          Task.Delay(1000).Wait();
          Debug.WriteLine(i.ToString());
          progress.Report(i);
        }
      });
    }

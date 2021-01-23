    public Task Method()
    {
      var context = SynchronizationContext.Current;
      return Task.Run(() =>
      {
        for (int i = 0; i < 100; i++)
        {
          Task.Delay(1000).Wait();
          Debug.WriteLine(i.ToString());
          var localI = i;
          current.Post(() =>
          {
            count = localI;
            onPropertyChanged("count");
          });
        }
      });
    }

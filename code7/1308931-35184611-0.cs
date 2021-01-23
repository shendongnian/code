    protected override async void OnStart ()
    {
      base.OnStart();
      await LoginAsync();
    }
    async Task LoginAsync()
    {
      await LoadCurrentProfile();
      if (ApplicationState.Profile == null)
      {
        GoLogin();
      }
      else
      {
        GoBegin();
      }
    }

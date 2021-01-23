    private async void OnRun(object sender, EventArgs args)
    {
      foreach (var case in Cases)
      {
        Base baseCaseRunner = GetCaseRunner(case);
        try
        {
          bool sync = !something_holds;
          bool ok = await baseCaseRunner.RunAsync(sync);
        }
        catch (Exception e)
        {
          LogError(...);
        }
      }
    }

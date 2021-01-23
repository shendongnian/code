    private async void OnRun(object sender, EventArgs args)
    {
        foreach (var case in Cases)
        {
            Base baseCaseRunner = GetCaseRunner(case);
            try
            {
                bool ok = true;
                ok = await baseCaseRunner.Run();
            }
            catch (Exception e)
            {
                LogError(...);
            }
        }
    }

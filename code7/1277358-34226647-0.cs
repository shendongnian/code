    public void StartSearchForUpdates()
    {
        if(!ApplicationDeployment.IsNetworkDeployed)
        {
            return;
        }
        bool updateAvailable = false;
        Task.Run(async () =>
        {
            while (!updateAvailable)
            {
                await Task.Delay(TimeSpan.FromHours(4));
                updateAvailable = ApplicationDeployment.CurrentDeployment.CheckForUpdate();
                if (UpdateAvailable)
                {
                    ApplicationDeployment.CurrentDeployment.UpdateAsync();
                    ApplicationDeployment.CurrentDeployment.UpdateCompleted += OnUpdatedCompleted;
                }
            }
        });
    }
    private void OnUpdatedCompleted(object sender, AsyncCompletedEventArgs e)
    {
        AvailableVersion = ApplicationDeployment.CurrentDeployment.UpdatedVersion;
    }

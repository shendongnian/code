    private void InstallUpdateSyncWithInfo()
        {
            if (!isNewUpdateMessageShown)
            {
                try
                {
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                        ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);
                        //ad_UpdateCompleted is a private method which handles what happens after the update is done
                        UpdateCheckInfo info = ad.CheckForDetailedUpdate();
                        if (info.UpdateAvailable)
                        {
                            //You can create a dialog or message that prompts the user that there's an update. Make sure the user knows that your are updating the application.
                            ad.UpdateAsync();//Updates the application asynchronously
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Log();
                }
            }
        }
        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Do something after the update. Maybe restart the application in order for the update to take effect.
            
        }

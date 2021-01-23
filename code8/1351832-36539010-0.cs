    private void InstallUpdateSyncWithInfo()
        {
            if (!isNewUpdateMessageShown)
            {
                "Checking Updates...".Log();
                try
                {
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                        ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);
                        UpdateCheckInfo info = ad.CheckForDetailedUpdate();
                        if (info.UpdateAvailable)
                        {
                            "Update Available...".Log();
                            isNewUpdateMessageShown = true;
                            this.WindowState = WindowState.Normal;
                            NewUpdateWindow newUpdateWindow = new NewUpdateWindow();
                            newUpdateWindow.Owner = this;
                            newUpdateWindow.ParentWindow = this;
                            bool? dialogResult = newUpdateWindow.ShowDialog();
                            switch (dialogResult ?? false)
                            {
                                case true:
                                    try
                                    {
                                        "Updating...".Log();
                                        ad.UpdateAsync();
                                        this.EnableDWMDropShadow = false;
                                        BorderThickness = new Thickness();
                                        ShowNotifyBaloon("You application is now installing updates", "This may take a while", "Application", false);
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Log();
                                    }
                                    break;
                                case false:
                                    "Update Cancelled...".Log();
                                    isNewUpdateMessageShown = false;
                                    appUpdateTimer.Start();
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Log();
                }
            }
        }

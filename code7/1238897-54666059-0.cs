     private int _dialogDisplayCount;
     private async void Logout_OnClick(object sender, RoutedEventArgs e)
            {
                try
                {    
                    _dialogDisplayCount++;
                    ContentDialog noWifiDialog = new ContentDialog
                    {
                        Title = "Logout",
                        Content = "Are you sure, you want to Logout?",
                        PrimaryButtonText = "Yes",
                        CloseButtonText = "No"
                    };
                    noWifiDialog.PrimaryButtonClick += ContentDialog_PrimaryButtonClick;
                    //await noWifiDialog.ShowAsync();
                    await noWifiDialog.EnqueueAndShowIfAsync(() => _dialogDisplayCount);
                }
                catch (Exception exception)
                {
                    _rootPage.NotifyUser(exception.ToString(), NotifyType.DebugErrorMessage);
                }
                finally
                {
                    _dialogDisplayCount = 0;
                }
            }

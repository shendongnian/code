    private async Task SignIn(ClientType clientType)
    {
        string refreshToken = null;
        AccountSession accountSession;
        // NOT the best place to save this, but will do for an example...
        refreshToken = Properties.Settings.Default.RefreshToken;
        if (this.oneDriveClient == null)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                this.oneDriveClient = clientType == ClientType.Consumer
                            ? OneDriveClient.GetMicrosoftAccountClient(
                                FormBrowser.MsaClientId,
                                FormBrowser.MsaReturnUrl,
                                FormBrowser.Scopes,
                                webAuthenticationUi: new FormsWebAuthenticationUi())
                            : BusinessClientExtensions.GetActiveDirectoryClient(FormBrowser.AadClientId, FormBrowser.AadReturnUrl);
            }
            else
            {
                this.oneDriveClient = await OneDriveClient.GetSilentlyAuthenticatedMicrosoftAccountClient(FormBrowser.MsaClientId,
                        FormBrowser.MsaReturnUrl,
                        FormBrowser.Scopes, 
                        refreshToken);
            }
        }
        try
        {
            if (!this.oneDriveClient.IsAuthenticated)
            {
                accountSession = await this.oneDriveClient.AuthenticateAsync();
                // NOT the best place to save this, but will do for an example...
                Properties.Settings.Default.RefreshToken = accountSession.RefreshToken;
                Properties.Settings.Default.Save();
            }
            await LoadFolderFromPath();
            UpdateConnectedStateUx(true);
        }
        catch (OneDriveException exception)
        {
            // Swallow authentication cancelled exceptions
            if (!exception.IsMatch(OneDriveErrorCode.AuthenticationCancelled.ToString()))
            {
                if (exception.IsMatch(OneDriveErrorCode.AuthenticationFailure.ToString()))
                {
                    MessageBox.Show(
                        "Authentication failed",
                        "Authentication failed",
                        MessageBoxButtons.OK);
                    var httpProvider = this.oneDriveClient.HttpProvider as HttpProvider;
                    httpProvider.Dispose();
                    this.oneDriveClient = null;
                }
                else
                {
                    PresentOneDriveException(exception);
                }
            }
        }
    }

    await ShowWebView();
    return new AccountSession(authenticationResponseValues, ServiceInfo.AppId,
                AccountType.MicrosoftAccount)
    {
        CanSignOut = true
    };
    private Task<bool> ShowWebView()
        {
            var tcs = new TaskCompletionSource<bool>();
            var auth = new OAuth2Authenticator(OneDriveAuthenticationConstants.MSA_CLIENT_ID, string.Join(",", OneDriveAuthenticationConstants.Scopes), new Uri(GetAuthorizeUrl()),
                new Uri(OneDriveAuthenticationConstants.RETURN_URL));
            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    OAuthErrorHandler.ThrowIfError(eventArgs.Account.Properties);
                    authenticationResponseValues = eventArgs.Account.Properties;
                    tcs.SetResult(true);
                }
            };
            var intent = auth.GetUI(Application.Context);
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
            return tcs.Task;
        }

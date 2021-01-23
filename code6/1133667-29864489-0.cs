    public static async Task<LiveLoginResult> LoginAsync()
    {
        List<String> oneDriveScopes = new List<String>() { "wl.signin", "wl.basic", "wl.skydrive_update" };
        LiveAuthClient authClient = new LiveAuthClient();
        LiveLoginResult authResult;
        try
        {
            authResult = await authClient.LoginAsync(oneDriveScopes);
        }
        catch
        {
            return null;
        }
        return authResult;
    }

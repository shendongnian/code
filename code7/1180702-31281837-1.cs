    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    {
        var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        var accessToken = loginInfo.ExternalIdentity.Claims
                        .Where(c => c.Type.EndsWith("facebook:access_token"))
                        .FirstOrDefault();
        ....
    }

    public static async Task<string> GetAccessTokenAsync()
    {
      var result = HttpContext.Current.Session["AccessToken"] as string;
      if (result != null)
        return result;
      ...
      var res = await authContext.AcquireTokenByAuthorizationCodeAsync(...);
      result = res.AccessToken.ToString();
      HttpContext.Current.Session["AccessToken"] = result;
      return result;
    }

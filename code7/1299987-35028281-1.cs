    public void Logout ()
    {
      CookieManager.Instance.RemoveAllCookie ();
      App.Client.Logout ();
    }
    
